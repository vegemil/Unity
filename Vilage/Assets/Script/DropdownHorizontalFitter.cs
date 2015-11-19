using UnityEngine;
using UnityEngine.UI;

public class DropdownHorizontalFitter : MonoBehaviour
{
    void Start()
    {
        RectTransform rectTransform = (RectTransform)transform;

        float width = rectTransform.rect.width;
        float scrollbarWidth = 0;

        //  If there's a scrollbar, get its width
        Scrollbar scrollbar = transform.parent.GetComponentInChildren<Scrollbar>();
        if (scrollbar != null)
        {
            scrollbarWidth = ((RectTransform)scrollbar.transform).rect.width;
        }

        //  Iterate through the texts (in the items) and find out which text + padding (+ scrollbar) is the longest,
        //  and set width to that, if it's longer than the caption width
        Text[] texts = GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            RectTransform offsetTransform = (RectTransform)texts[0].transform;
            width = Mathf.Max(width, Mathf.Abs(offsetTransform.offsetMin.x) + Mathf.Abs(offsetTransform.offsetMax.x) + texts[i].preferredWidth + scrollbarWidth);
        }

        //  Set new width
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);

        //  Get right edge of dropdown and right edge of root canvas,
        //  if the dropdown goes off the canvas on the right, make it go to the left instead
        Canvas rootCanvas = GetComponentInParent<Canvas>();
        if (rootCanvas != null)
        {
            while (!rootCanvas.isRootCanvas)
            {
                rootCanvas = rootCanvas.transform.parent.GetComponentInParent<Canvas>();
            }

            Vector3[] corners = new Vector3[4];

            rectTransform.GetWorldCorners(corners);
            float rectTransformRightEdge = corners[2].x;

            ((RectTransform)rootCanvas.transform).GetWorldCorners(corners);
            float rootCanvasRightEdge = corners[2].x;

            if (rectTransformRightEdge > rootCanvasRightEdge)
            {
                rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, width);
            }
        }
    }
}