using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttributes : MonoBehaviour
{

    [SerializeField] float attackDamage;
    [SerializeField] float speed;
    [SerializeField] float karma = 50;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    [SerializeField] private Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        karma = 50;
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //   OnMouseClick();
        //}
    }


    void OnMouseDown()
    {
        currentHealth -= 5f;

        if (currentHealth <= 0)
        {

            Destroy(gameObject);
        }
        else
        {
            healthbar.UpdateHealthBar(maxHealth, currentHealth);

        }
    }
}
