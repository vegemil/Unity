using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {

   public string SceneName;

    public void OnClick()
    {
        Debug.Log("click!!");
        Application.LoadLevel(SceneName);
    }

}
