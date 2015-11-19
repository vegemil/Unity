using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DropFix : MonoBehaviour
{
  [Tooltip("Any further amount to add to the right of the calculated width of the DropDown panel.")]
  public float Padding = 0;
  [Tooltip("Whether this should keep its DropDown panel constrained within the width of the game view (Unity automatically handles the vertical). Standard Windows operation is to run off the side of the window or screen.")]
  public bool ConstrainToCanvas = true;
  [Tooltip("If true, this will constrain its DropDown panel to the rect of the parent canvas, rather than the root. May be useful for custom windows.")]
  public bool UseParentCanvas = false;

  private ScrollRect Template;
  void Start()
  {
    Template = GetComponent<ScrollRect>();
    if (Template == null)
    {
      Debug.LogError("DropFix script needs to be on the 'Template' object, dummy.");
      return;
    }

    //Delay one frame so we can be sure the dropdown has finished its processing, in 
    // particular enabling/disabling the scrollbar.
    StartCoroutine(StartDelay());
  }

  IEnumerator StartDelay()
  {
    //Set the wrap mode for each text object to overflow.  If this is not done, then individual
    // characters will be wrapped unless excessive space is allotted.
    Text[] Items = GetComponentsInChildren<Text>();
    foreach (Text child in Items)
      child.horizontalOverflow = HorizontalWrapMode.Overflow;

    //Ensure the dropdown finishes enabling/disabling the scrollbar, and let the text boxes update.
    yield return null;

    //Start with the default dropdown width and see if we need to make it bigger
    // based on the requested width and position of the text controls.
    RectTransform RT = transform as RectTransform;
    float width = RT.rect.width;
    
    foreach (Text child in Items)
    {
      float max = child.preferredWidth + Mathf.Abs(((RectTransform)child.transform).offsetMax.x);

      if (max > width)
        width = max;
    }

    //If the scroll bar is visible, we need more padding. Note that the scrollbar is /always/ part
    // of the default template, but has just been disabled if it is unneeded.
    Scrollbar scrollbar = Template.verticalScrollbar;
    float scrollWidth = 0;
    if (scrollbar != null && scrollbar.gameObject.activeSelf)
      scrollWidth = ((RectTransform)scrollbar.transform).rect.width;

    //combine the new minimum width, the width of the scrollbar, and any user-defined padding.
    width += scrollWidth + Padding;

    //set new width.
    RT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);

    if (!ConstrainToCanvas)
      yield break;

    // Get right edge of dropdown and right edge of root canvas,
    //  if the dropdown goes off the canvas on the right, make it go to the left instead
    Canvas rootCanvas = GetComponentInParent<Canvas>();
    if (rootCanvas != null)
    {
      //While most people will want the root canvas, some might perhaps want nested canvases to
      // instead be the limit, such as with custom windows.
      if(!UseParentCanvas)
        while (!rootCanvas.isRootCanvas)
          rootCanvas = rootCanvas.transform.parent.GetComponentInParent<Canvas>();

      Vector3[] corners = new Vector3[4];

      RT.GetWorldCorners(corners);
      float rectTransformRightEdge = corners[2].x;

      ((RectTransform)rootCanvas.transform).GetWorldCorners(corners);
      float rootCanvasRightEdge = corners[2].x;

      if (rectTransformRightEdge > rootCanvasRightEdge)
        RT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, width);
    }
  }
}
