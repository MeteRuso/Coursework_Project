using UnityEngine;
using System.Collections;

public class CrossHairRayCast : MonoBehaviour
{

    #region Variables

    //The Crosshair as a 2D rectangle
    Rect crosshairObjectSprite;
    //The image to be used for the Crosshair
    Texture crosshairTexture;
    Texture specialCrosshairTexture;
    // The size of the crosshair scales with the screen size so it is relative to the resolution
    float crossHairSize = Screen.width * 0.035f;

    RaycastHit InteractionInfo;
    //A string to store the filepath of the icon used when the mouse is hovering over an interactable object
    string iconResourceFilePath;
    bool specialIcon = false;

    #endregion

    // Use this for initialization
    void Start()
    {
        //Loads the selected file once the program runs
        crosshairTexture = Resources.Load("Textures/Crosshair") as Texture;
        //Resources.Load("Textures/Door") as Texture;
        //Crosshair is positioned using the top left corner as the coordinate. This centres the crosshair and decides the size
        crosshairObjectSprite = new Rect(Screen.width / 2 - crossHairSize / 2, Screen.height / 2 - crossHairSize / 2, crossHairSize, crossHairSize);
    }

    void Update()
    {
        bool lookingAtObject = true;
        Debug.DrawRay(this.transform.position, this.transform.forward * 4, Color.cyan);

        #region Special Crosshairs

        //Shoots a raycast from the object this script is placed on (Camera) of length 4 units
        //and save the data of any collisions the the variable: InteractionInfo

        if (Physics.Raycast(this.transform.position, this.transform.forward, out InteractionInfo, 4))
        {
            //This changes the special crosshair corresponding to the tag of the object.
            specialIcon = true;
            if (InteractionInfo.collider.gameObject.tag == "Chest")
            {
                specialCrosshairTexture = Resources.Load("Textures/Crosshairs/Crate") as Texture;
                //Debug.Log("Texture crate thing");
            }
            else if (InteractionInfo.collider.gameObject.tag == "Door")
            {
                specialCrosshairTexture = Resources.Load("Textures/Crosshairs/Door") as Texture;
                //Debug.Log("Texture door thing");
            }
            else if (InteractionInfo.collider.gameObject.tag == "Item")
            {
                specialCrosshairTexture = Resources.Load("Textures/Crosshairs/Hand") as Texture;
                //Debug.Log("Texture Item thing");
            }
            else if (InteractionInfo.collider.gameObject.tag == "NPC")
            {
                specialCrosshairTexture = Resources.Load("Textures/Crosshairs/Speech") as Texture;
                //Debug.Log("Texture Npc thing");
            }
            else
            {
                // This is neccesary to reset the crosshair whn looking at an object that isn't interactable
                specialCrosshairTexture = Resources.Load("Textures/Crosshairs/Crosshair") as Texture;
                lookingAtObject = false;
                //Debug.Log("Texture none thing")
            }

            

            if (lookingAtObject == true)
            {
                CheckInteraction(InteractionInfo.collider.gameObject);
            }


        }
        else
        {
            specialIcon = false;
            crosshairTexture = Resources.Load("Textures/Crosshairs/Crosshair") as Texture;
        }

        #endregion

    }

    // Update is called once per frame to put objects on the User interface
    void OnGUI()
    {
        //Draws the crosshair on the screen
        if (specialIcon == false)
            //Default crosshair
        { GUI.DrawTexture(crosshairObjectSprite, crosshairTexture); }
        else
            //Interactable crosshair
        { GUI.DrawTexture(crosshairObjectSprite, specialCrosshairTexture); }
    }

    void CheckInteraction(GameObject checkObject)
    {
        if (Input.GetKey("e"))
        {
            Interactable newObject = checkObject.GetComponent<Interactable>();
            newObject.EInteract(checkObject);
         
        }
    }

}
