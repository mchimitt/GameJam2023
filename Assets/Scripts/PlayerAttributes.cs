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

    [SerializeField] Healthbar healthbar;
    [SerializeField] KarmaMeter karmaMeter;

    void Start()
    {
        //currentKarma = 50;
        karmaMeter.UpdateKarmaMeter(maxKarma, currentKarma);

        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);

    }



    public void PlayerPickUp(float karmaValue)
    {

        karmaMeter.UpdateKarmaMeter(maxKarma, currentKarma += karmaValue);
    }

    public void PlayerTakeDamage(float damageValue)
    {

        healthbar.UpdateHealthBar(maxHealth, (currentHealth -= damageValue));
    }
}
