using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] PlayerAttributes player1Damage;
    [SerializeField] PlayerAttributes player2Damage;
    [SerializeField] PlayerAttributes player3Damage;
    [SerializeField] PlayerAttributes player4Damage;

    [SerializeField] float damageValue;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("detect player");
        if(other.tag == "Player1")
        {
            Debug.Log("p1 hit");
            player1Damage.PlayerTakeDamage(damageValue);
        }

        if (other.tag == "Player2")
        {
            Debug.Log("p2 hit");
            player2Damage.PlayerTakeDamage(damageValue);
        }
    }


}
