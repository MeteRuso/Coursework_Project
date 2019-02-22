using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public enum AIState
    {
        IDLE,
        AGGRO,
        INVEST,
        FLEE
    }

    public enum WeaponState
    {
        MELEE,
        RANGER,
        MAGE
    }

    public enum ResourceState
    {
        Topped,
        OOS,
        OOM,
        OOH,
        Diminish
    }


    public int enemySpeed = 3;
    public bool Visible = false;
    public bool Investigated = true;
    RaycastHit InteractionInfo;

    public Vector3 lastKnownPos;
    public Vector3 playerPos;
    public Vector3 directionToPlayer;
    NavMeshAgent myNavMesh;

    CharacterStats StatCall = GetComponentInParent<CharacterStats>();
    AIState AIstate;


    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        EnemyController();
    }

    public void EnemyController()
    {
        Visible = VisionCone();
        if (Visible == false)
        {
            enemySpeed = 3;
            Investigate();
            Roam();
            ////Pickup();
        }
        else
        {
            enemySpeed = 4;
            MoveToPlayer();
            lastKnownPos = playerPos;
            //Combat();
            ////CheckStats();
            ////SwordAttack();
            ////RangedAttack();
            ////Block();
            ////Retreat();
        }
    }

    #region State Changes
    void UpdateStates()
    {
        if (Visible)
        {
            AIstate = AIState.AGGRO;
        }
        else if (ResourceState)
        {
            AIstate = AIState.FLEE;
        }
        else if (!Visible && (Investigated = false))
        {
            AIstate = AIState.INVEST;
        }
        else
        {
            AIstate = AIState.IDLE;
        }

        if ()
    }
    #endregion

    #region Sensory
    public bool VisionCone()
    {
        float lookAngle = 0f;
        bool canSee = false;
        Debug.DrawRay(gameObject.transform.position, playerPos, Color.red);


        float dotProd = Vector3.Dot(this.transform.forward, directionToPlayer);
        float magnitudeOfVect = (Vector3.Magnitude(directionToPlayer) * Vector3.Magnitude(this.transform.forward));
        lookAngle = Mathf.Acos(dotProd / magnitudeOfVect);
        lookAngle = lookAngle * 180 / Mathf.PI;
        Debug.Log("Angle is " + lookAngle);

        if (Physics.Raycast(this.transform.position, directionToPlayer, out InteractionInfo, 15))
        {
            if (InteractionInfo.collider.gameObject.tag == "Player")
            {
                if (lookAngle < 70)
                {
                    canSee = true;
                }
                else
                {
                    canSee = false;
                }
            }
            else
            {
                canSee = false;
            }
        }

        return canSee;
    }
    public void UpdateTransforms()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        directionToPlayer = (gameObject.transform.position - playerPos).normalized;
    }
    #endregion

    #region Behaviours
    public void Roam()
    {
        NavMeshHit Hit;
        Vector3 randomSample;
        randomSample.x = Random.Range(-20, 20);
        randomSample.y = 0;
        randomSample.z = Random.Range(-20, 20);

        NavMesh.SamplePosition(randomSample, out Hit, 2, 0);
        myNavMesh = GetComponent<NavMeshAgent>();

        if (Visible == false)
        {
            myNavMesh.SetDestination(Hit.normal);
        }
    }
    public void Investigate()
    {
        if (lastKnownPos != null)
        {
            Vector3 lastKnownDir = (gameObject.transform.position - lastKnownPos).normalized;
            gameObject.GetComponent<CharacterController>().Move(-enemySpeed * (lastKnownDir * Time.deltaTime));
            gameObject.transform.forward = lastKnownDir;
        }
    }
    void MoveToPlayer()
    {
        UpdateTransforms();
        gameObject.GetComponent<CharacterController>().Move(-enemySpeed * (directionToPlayer * Time.deltaTime));
        gameObject.transform.forward = directionToPlayer;
    }
    #endregion



}
