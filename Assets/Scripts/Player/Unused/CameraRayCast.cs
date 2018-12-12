using UnityEngine;
using System.Collections;

public class CameraRayCast : MonoBehaviour {

    //This is where the information about the object that the raycast has hit will be stored.
    //It will give us access to the object's collider as thus will give access to the game object
    RaycastHit InteractionInfo;
    //A string to store the filepath of the icon used when the mouse is hovering over an interactable object
    string iconResourceFilePath;


	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, this.transform.forward * 4, Color.cyan);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out InteractionInfo, 4))
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //tHIS IS A USELESS COMMENT XD
            //{
                if (InteractionInfo.collider.gameObject.tag == "Interactable")
                {
                    if (InteractionInfo.collider.gameObject.tag == "Chest")
                    { iconResourceFilePath = "Textures/Crate"; }
                    else if (InteractionInfo.collider.gameObject.tag == "Door")
                    { iconResourceFilePath = "Textures/Door"; }
                    else if (InteractionInfo.collider.gameObject.tag == "Item")
                    { iconResourceFilePath = "Textures/Hand"; }
                    else if (InteractionInfo.collider.gameObject.tag == "NPC")
                    { iconResourceFilePath = "Textures/Speech"; }
                }
            //}
        }


    }



}
