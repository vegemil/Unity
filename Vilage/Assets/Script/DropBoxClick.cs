using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropBoxClick : MonoBehaviour {

    public Dropdown dropdown;
    private Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        dropdown.onValueChanged.AddListener(DropdownValueChange);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DropdownValueChange(int value)
    {
        image.sprite = dropdown.options[value].image;
        Debug.Log(dropdown.options[value].image.name);
    }
}
