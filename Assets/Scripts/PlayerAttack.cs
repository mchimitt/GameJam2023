using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public List<Transform> attackPoints;

    NewPlayerMovement npm;

    [SerializeField] PlayerInput playerInput;

    [SerializeField] LayerMask enemy;

    public Animator myAnimator;
    public float delay = 0.3f;
    private bool attackBlocked;

    [SerializeField] BoxCollider bc;

    public bool isAttacking = false;

    private void Start()
    {
        npm = GetComponent<NewPlayerMovement>();
        bc.enabled = false;
    }

    private void Update()
    {
        InputAction attackAction = playerInput.actions.FindAction("Attack");

        if(attackAction.triggered)
        {
            Debug.Log("CLicked");
        }

        if (attackAction.triggered && !isAttacking)
        {
            Debug.Log("ATTACKING WOOOO");
            myAnimator.SetTrigger("AttackSide");
            isAttacking = false;
            bc.enabled = true;

            float playerDirection = npm.playerDirection;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            //Mathf.Infinity
            if (Physics.Raycast(transform.position, transform.TransformDirection(playerDirection,0,0), out hit, 3f, enemy))
            {
                Debug.Log("hit: " + hit.transform.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(playerDirection,0,0) * hit.distance, Color.yellow);
                // Debug.Log("Did Hit");

                Destroy(hit.transform.gameObject);
                

            }
            StartCoroutine(DelayAttack());
            
        } 
    }

    public void Attack()
    {
        if (attackBlocked)
            return;

        myAnimator.SetTrigger("Attack"); //change to specific attack animations
        attackBlocked = true;

        

        StartCoroutine(DelayAttack());
        isAttacking = true;
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == enemy) { 
            Debug.Log("COLLIDED WITH " + other);
            bc.enabled = false;
        }
    }

}
