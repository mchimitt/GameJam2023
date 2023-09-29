using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] float karmaValue;

    private PlayerAttributes itemPowerup;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player grabed item");
        if (other.tag == "Player")
        {
            Debug.Log("item detected player");

            itemPowerup.PlayerPickUp(karmaValue);

            Debug.Log("destroy item");
            
        }
        
        Destroy(gameObject);
    }
}
