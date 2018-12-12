using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    CharacterController charControl;
    //Variable for the speed of the player
    public float moveSpeedMultiplier = 700f;

	void Awake () {
        //Calls the class of CharacterController to be able to access its methods
        charControl = GetComponent<CharacterController>();
	}

    //calls the MovePlayer Method every frame
    void Update () {
        MovePlayer();
	}

    void MovePlayer ()
    {
        //Gets the inputs for moving in a direction using the universal keys: WASD
        float xDirectionalInput = Input.GetAxis("Horizontal");
        float zDirectionalInput = Input.GetAxis("Vertical");

        //The actual transformation
        Vector3 vectMovementLeftRight = transform.right * xDirectionalInput * moveSpeedMultiplier * Time.deltaTime;
        Vector3 vectMovementForwardBack = transform.forward * zDirectionalInput * moveSpeedMultiplier * Time.deltaTime;
        //Using Time.deltaTime to make movement exclusive from framerate.
        //Since the method is called every frame, time.deltatime is the time delay since the last frame so by multiplying this with my transformations
        //will slow down high framerate devices and speed up low framerate devices

        charControl.SimpleMove(vectMovementLeftRight);
        charControl.SimpleMove(vectMovementForwardBack);
    }
}
