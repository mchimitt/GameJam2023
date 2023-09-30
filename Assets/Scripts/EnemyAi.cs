using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    //[SerializeField] protected Targetable _target;

    public NavMeshAgent agent;
    //public Transform player;
    public Collider[] playerToChase;

    public LayerMask whatIsGround, whatIsPlayer;

    private bool _hasTarget;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Sprites and Animation
    public float flipDistance = 1.0f;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        if (!agent) agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the enemy object.");
        }

        myAnimator = GetComponentInChildren<Animator>();
        if (myAnimator == null)
        {
            Debug.LogError("Animator component not found on the enemy object.");
        }

        agent.updateRotation = false;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        Debug.Log(playerInSightRange);
        Debug.Log(playerInAttackRange);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }
    private void ChasePlayer()
    {
        playerToChase = Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer);
        FlipSpriteBasedOnPlayerPosition();
        agent.SetDestination(playerToChase[0].transform.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        if (playerToChase.Length > 0)
            FlipSpriteBasedOnPlayerPosition();
        else playerToChase = Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer);


        if (!alreadyAttacked)
        {
            ///Attack code here
            ///
            ///
            myAnimator.SetTrigger("Attack");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void FlipSpriteBasedOnPlayerPosition()
    {
        if (playerToChase.Length > 0)
        {
            float playerDistance = playerToChase[0].transform.position.x - transform.position.x;

            // Check if the player is to the right or left based on the threshold
            if (Mathf.Abs(playerDistance) > flipDistance)
            {
                // Flip the sprite
                if (playerDistance > 0)
                {
                    spriteRenderer.flipX = true;  // Face right
                }
                else
                {
                    spriteRenderer.flipX = false;   // Face left
                }
            }
        }
    }
            
}

    //protected bool CheckTarget()
    //{
    //    var targets = Targetable.GetAllWithinRange(transform.position, sightRange);
    //    var target = GetPotentialTarget(targets);
    //    _target = target;
    //    _hasTarget = _target;
    //    return _hasTarget;
    //}
    //
    //protected abstract Targetable GetPotentialTarget(IEnumerable<Targetable> potentialTargets);
    //
    //protected bool CheckAttackTarget()
    //{
    //    return (Vector3.Distance(transform.position, _target.transform.position) < attackRange);
    //}

