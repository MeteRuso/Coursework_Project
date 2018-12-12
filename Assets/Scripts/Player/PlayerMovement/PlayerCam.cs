using UnityEngine;
using System.Collections;

public class PlayerCam : MonoBehaviour {

    #region Variables

    //Multiplier for the movement of the mouse, initialised at 3
    public float mouseSensitivity = 3f;

    public Transform playerBody;
    float xAxisClamp;

    #endregion

    // Update is called once per frame
    void Update () {
        RotateCam();
	}

    void RotateCam()
    {

        #region Input & Calc

        //Decaring X and Y axis variables
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // The actual amount of rotation based of mouse movement and sensitivity. 
        
        float rotationX = mouseX * mouseSensitivity;
        float rotationY = mouseY * mouseSensitivity;

        xAxisClamp -= rotationY;

        Vector3 camRotaion = transform.rotation.eulerAngles;
        Vector3 bodyRotaion = playerBody.rotation.eulerAngles;

        //Adding the rotation values in degrees to the rotaion of the camera
        //X and Y are reversed so they move the camera in the correct axis. 
        //MouseY in negative because it inverts the controls otherwise.
        camRotaion.x -= rotationY;
        camRotaion.z = 0;
        bodyRotaion.y += rotationX;

        #endregion

        #region Clamp

        //Locks camera rotation to straight up and down to prevent camera flipping
        if (xAxisClamp > 85)
        {
            xAxisClamp = 85;
            camRotaion.x = 85;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            camRotaion.x = 270;
        }

        #endregion

        #region Transform

        //Convert Vector to Quart
        transform.rotation = Quaternion.Euler(camRotaion);
        playerBody.rotation = Quaternion.Euler(bodyRotaion);

        #endregion
    }

}
