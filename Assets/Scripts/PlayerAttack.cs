using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public List<Transform> attackPoints;

    [SerializeField] PlayerInput playerInput;

    public Animator myAnimator;
    public float delay = 0.3f;
    private bool attackBlocked;

    public bool isAttacking = false;

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
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

}
