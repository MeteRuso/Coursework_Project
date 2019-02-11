using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int enemySpeed = 2;
    private GameObject PlayerPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveToPlayer();
	}

    void MoveToPlayer()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 directionToPlayer = (gameObject.transform.position - playerPos).normalized;
        gameObject.GetComponent<CharacterController>().Move(-enemySpeed*(directionToPlayer*Time.deltaTime));
        gameObject.transform.forward = directionToPlayer;
    }
    
    public bool VisionCone()
    {
        bool canSee = false;
        //Debug.DrawRay(gameObject.transform.position);


        return canSee;
    }

}
