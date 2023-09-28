using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float sightRange = 10.0f;

    public Transform target;
    //public GameObject player2Tracking;
    //public GameObject player3Tracking;
    //public GameObject player4Tracking;

    private Rigidbody rb;


    void FollowPlayer()
    {

        // Calculate the direction from the enemy to the player
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate the desired movement amount
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
