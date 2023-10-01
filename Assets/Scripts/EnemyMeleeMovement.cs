using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float sightRange = 10.0f;

    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;



    private Rigidbody rb;


    void FollowPlayer()
    {

        // Calculate the direction from the enemy to the player
        Vector3 direction = (target1.position - transform.position).normalized;

        // Calculate the  movement amount
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // Move the enemy towards the player
        transform.Translate(movement);

        // Turn to player
        //transform.LookAt(target);
    }

    void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            FollowPlayer();
        }
    }

}
