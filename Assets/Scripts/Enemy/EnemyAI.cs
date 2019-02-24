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
        MAGE,
        SHIELD
    }

    public enum ResourceState
    {
        Topped,
        OOS,
        OOM,
        OOH,
    }


    public int enemySpeed = 3;
    public float distance;
    private float distanceToSpot = 1f;
    private bool firstPosCalculated = false;
    public bool Visible = false;
    public bool Investigated = true;
    RaycastHit InteractionInfo;

    public Vector3 lastKnownPos;
    public Vector3 playerPos;
    public Vector3 directionToPlayer;
    Vector3 hitPosition;
    NavMeshAgent myNavMesh;

    EnemyStats StatCall;
    AIState AIstate;
    ResourceState ResourcesState;
    WeaponState WeaponsState;

    // Use this for initialization
    void Start() {
        StatCall = GetComponentInParent<EnemyStats>();
        myNavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        Environment();
        UpdateStates();
        Act();
        InvokeRepeating("CheckState", 5f, 5f);
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
        if (Visible && ResourcesState == ResourceState.Topped)
        {
            AIstate = AIState.AGGRO;
            Investigated = false;
        }
        else if (ResourcesState == ResourceState.OOH || ResourcesState == ResourceState.OOS)
        {
            AIstate = AIState.FLEE;
        }
        else if (!Visible && (Investigated == false) && ResourcesState == ResourceState.Topped)
        {
            AIstate = AIState.INVEST;
        }
        else
        {
            AIstate = AIState.IDLE;
        }

            if (StatCall.currentHealth.GetValue() < 10)
            {
                ResourcesState = ResourceState.OOH;
            }
            else if (StatCall.currentStamina.GetValue() / StatCall.maxStamina.GetValue() < 0.05)
            {
                ResourcesState = ResourceState.OOS;
            }
            else if (StatCall.currentMana.GetValue() / StatCall.maxMana.GetValue() < 0.1)
            {
                ResourcesState = ResourceState.OOM;
            }
            else
            {
                ResourcesState = ResourceState.Topped;
            }
     
        //if ()
        //{
        //    WeaponsState = WeaponState.SHIELD;
        //}
        //else if ()
        //{
        //    WeaponsState = WeaponState.RANGER;
        //}
        //else if ()
        //{
        //    WeaponsState = WeaponState.MAGE;
        //}
        //else if ()
        //{
        //    WeaponsState = WeaponState.MELEE;
        //}
    }

    public void CheckState()
    {
        Debug.Log(AIstate);
    }
    #endregion

    #region Sensory
    public void Environment()
    {
        UpdateTransforms();
        Visible = VisionCone();
        //Debug.Log(Visible);
        
    }
    public bool VisionCone()
    {
        
        float lookAngle;
        bool canSee = false;
        Debug.DrawRay(gameObject.transform.position, directionToPlayer * distance, Color.red);


        float dotProd = Vector3.Dot(this.transform.forward, directionToPlayer);
        float magnitudeOfVect = (Vector3.Magnitude(directionToPlayer) * Vector3.Magnitude(this.transform.forward));
        lookAngle = Mathf.Acos(dotProd / magnitudeOfVect);
        lookAngle = 180 - (lookAngle * 180 / Mathf.PI);
        //Debug.Log("Angle is " + lookAngle);

        if (Physics.Raycast(this.transform.position, -directionToPlayer, out InteractionInfo, 15))
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
        distance = Vector3.Distance(gameObject.transform.position, playerPos);
    }
    #endregion

    #region Acting
    public void Act()
    {
        if (AIstate == AIState.AGGRO)
        {
            MoveToPlayer();
            //Combat
            ///Melee
            ////MoveToPlayer
            ///Ranged
            ////GetRange
            ////Kite
        }
        else if (AIstate == AIState.FLEE)
        {
            //FleePlayer
            ///FindHealth
            ///FindPickup
        }
        else if (AIstate == AIState.INVEST)
        {
            Investigate();
        }
        else if (AIstate == AIState.IDLE)
        {
            Roam();
            ///FindPickup
        }
    }
    #endregion

    #region Behaviours
    public void Roam()
    {
        
        Vector3 randomSample;
        
        randomSample.y = 1;
        randomSample.x = 1;
        randomSample.z = 1;
        NavMeshHit Hit;
        
        myNavMesh.isStopped = false;

        if (firstPosCalculated == false)
        {
            randomSample.x = Random.Range(-19, 19);
            randomSample.z = Random.Range(-19, 19);
            firstPosCalculated = true;
            NavMesh.SamplePosition(randomSample, out Hit, 5, NavMesh.AllAreas);
            hitPosition = Hit.position;
            distanceToSpot = Vector3.Distance(Hit.position, gameObject.transform.position);
            myNavMesh.SetDestination(Hit.position);
        }

        //Debug.Log("x = " + randomSample.x);
        //Debug.Log("z = " + randomSample.z);
        //Debug.Log("Vis = " + Visible);
        
        distanceToSpot = Vector3.Distance(hitPosition, gameObject.transform.position);
        //Debug.Log(distanceToSpot);

        if (distanceToSpot < 1.5 && Visible == false)
        {
            //Debug.Log("pick new random");
            randomSample.x = Random.Range(-19, 19);
            randomSample.z = Random.Range(-19, 19);
            //Debug.Log("x = " + randomSample.x);
            //Debug.Log("z = " + randomSample.z);

            NavMesh.SamplePosition(randomSample, out Hit, 5, NavMesh.AllAreas);
            hitPosition = Hit.position;
            
            //Debug.Log(distanceToSpot);
            myNavMesh.SetDestination(Hit.position);


        }

    }
    public void Investigate()
    {
        float distanceToLastLocation;
        if (Investigated == false && Visible == false)
        {
            Vector3 lastKnownDir = (gameObject.transform.position - lastKnownPos).normalized;
            gameObject.GetComponent<CharacterController>().Move(enemySpeed * (-lastKnownDir * Time.deltaTime));
            gameObject.transform.forward = -lastKnownDir;
            distanceToLastLocation = Vector3.Distance(gameObject.transform.position, lastKnownPos);
            if (distanceToLastLocation < 1.5f)
            {
                Investigated = true;
            }
        }
    }
    void MoveToPlayer()
    {
        if (distance > 0.75f)
        {
            lastKnownPos = playerPos;
            myNavMesh.isStopped = true;
            gameObject.GetComponent<CharacterController>().Move(enemySpeed * (-directionToPlayer * Time.deltaTime));
            gameObject.transform.forward = -directionToPlayer;
        }
    }
    #endregion



}
