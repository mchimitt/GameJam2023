using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public List<Transform> attackPoints;

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;



    public void Attack()
    {
        if (attackBlocked)
            return;

        animator.SetTrigger("Attack"); //change to specific attack animations
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

}
