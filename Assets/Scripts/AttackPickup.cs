using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    [SerializeField] float karmaValue;

    [SerializeField] float attackBoost;

    [SerializeField] PlayerAttributes player1Pickup;
    [SerializeField] PlayerAttributes player2Pickup;
    [SerializeField] PlayerAttributes player3Pickup;
    [SerializeField] PlayerAttributes player4Pickup;

    private void Awake()
    {
        karmaValue = 5;

        attackBoost = 1;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player1")
        { 
            player1Pickup.PlayerPickUp(karmaValue);

            Debug.Log("calls attack boost");
            player1Pickup.AttackBoost(attackBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player2")
        {
            player2Pickup.PlayerPickUp(karmaValue);

            player2Pickup.AttackBoost(attackBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player3")
        {
            player3Pickup.PlayerPickUp(karmaValue);

            player3Pickup.AttackBoost(attackBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player4")
        {
            player4Pickup.PlayerPickUp(karmaValue);

            player4Pickup.AttackBoost(attackBoost);

            gameObject.SetActive(false);
        }
    }
}
