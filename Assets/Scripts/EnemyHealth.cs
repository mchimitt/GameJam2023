using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private List<GameObject>() Loot;
    [SerializeField] private Animator poof;
 
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Debug.Log(currentHealth);
            foreach(Gameobjet gameobject in Loot)
            {
                Instantiate(this, gameobject);
            }
        }

        poof.GameObject.SetActive(true);
    }
}
