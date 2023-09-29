using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    [SerializeField] float attackDamage;
    [SerializeField] float speed;

    [SerializeField] float maxKarma = 100;
    [SerializeField] float currentKarma;

    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    [SerializeField] private Healthbar healthbar;
    [SerializeField] private KarmaMeter karmaMeter;
    // Start is called before the first frame update
    void Start()
    {
        //currentKarma = 50;
        karmaMeter.UpdateKarmaMeter(maxKarma, currentKarma);

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

    public void PlayerPickUp(float karmaValue)
    {

        karmaMeter.UpdateKarmaMeter(maxKarma, currentKarma+karmaValue);
    }
}
