using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : Interactable {

    public override void EInteract(GameObject SceneName)
    {
        //base.EInteract();
        SceneManager.LoadScene(SceneName.name);
    }

}
