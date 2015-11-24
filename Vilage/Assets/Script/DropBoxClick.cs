using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropBoxClick : MonoBehaviour {

    private Dropdown dropdown;
    //private Image image;
    private GameObject houses;

	// Use this for initialization
	void Start () {
        //image = GetComponent<Image>();
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(DropdownValueChange);

        houses = new GameObject();
        houses.transform.name = "Houses";

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DropdownValueChange(int value)
    {
        //image.sprite = dropdown.options[value].image;
        Debug.Log(dropdown.options[value].image.name);
        GameObject prefab = Resources.Load("Prefab/" + dropdown.options[value].image.name)as GameObject;
        GameObject house = Instantiate(prefab) as GameObject;

        house.transform.parent = houses.transform;

    }
}
