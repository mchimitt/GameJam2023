using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] float damageValue;

    [SerializeField] PlayerAttributes player1Damage;
    [SerializeField] PlayerAttributes player2Damage;
    [SerializeField] PlayerAttributes player3Damage;
    [SerializeField] PlayerAttributes player4Damage;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player1")
        {
            player1Damage = other.GetComponent<PlayerAttributes>();

            player1Damage.PlayerTakeDamage(damageValue);
        }

        if (other.tag == "Player2")
        {
            player2Damage = other.GetComponent<PlayerAttributes>();

            player2Damage.PlayerTakeDamage(damageValue);
        }

        if (other.tag == "Player3")
        {
            player3Damage = other.GetComponent<PlayerAttributes>();

            player3Damage.PlayerTakeDamage(damageValue);
        }

        if (other.tag == "Player4")
        {
            player4Damage = other.GetComponent<PlayerAttributes>();

            player4Damage.PlayerTakeDamage(damageValue);
        }
    }
}
