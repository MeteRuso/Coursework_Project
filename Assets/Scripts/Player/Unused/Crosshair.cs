using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    //The Crosshair as a 2D rectangle
    Rect crosshairObjectSprite;
    //The image to be used for the Crosshair
    Texture crosshairTexture;
    // The size of the crosshair scales with the screen size so it is relative to the resolution
    float crossHairSize = Screen.width * 0.02f;


	void Start () {
        //Loads the selected file once the program runs
        crosshairTexture = Resources.Load("Textures/Crosshair") as Texture;
        //Crosshair is positioned using the top left corner as the coordinate. This centres the crosshair and decides the size
        crosshairObjectSprite = new Rect(Screen.width / 2 - crossHairSize / 2, Screen.height / 2 - crossHairSize / 2, crossHairSize, crossHairSize);
	}
    
    // Update is called once per frame to put objects on the User interface
    void OnGUI () {
        //Draws the crosshair on the screen
        GUI.DrawTexture(crosshairObjectSprite, crosshairTexture);
	}
}
