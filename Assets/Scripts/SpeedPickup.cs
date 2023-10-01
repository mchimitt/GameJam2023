using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    [SerializeField] float karmaValue;

    [SerializeField] float speedBoost;

    [SerializeField] PlayerAttributes player1Pickup;
    [SerializeField] PlayerAttributes player2Pickup;
    [SerializeField] PlayerAttributes player3Pickup;
    [SerializeField] PlayerAttributes player4Pickup;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player1")
        {
            player1Pickup.PlayerPickUp(karmaValue);

            player1Pickup.SpeedBoost(speedBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player2")
        {
            player2Pickup.PlayerPickUp(karmaValue);

            player2Pickup.SpeedBoost(speedBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player3")
        {
            player3Pickup.PlayerPickUp(karmaValue);

            player3Pickup.SpeedBoost(speedBoost);

            gameObject.SetActive(false);
        }

        if (other.tag == "Player4")
        {
            player4Pickup.PlayerPickUp(karmaValue);

            player4Pickup.SpeedBoost(speedBoost);

            gameObject.SetActive(false);
        }
    }
}
