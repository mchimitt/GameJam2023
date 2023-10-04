using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private List<GameObject> Loot;
    [SerializeField] private Animator poof;
 
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        //if (_healthBar)
        _healthBar.fillAmount = currentHealth / maxHealth;

        //else if (!_healthBar)
        //    _healthBar = GetComponent

        if (currentHealth <= 0)
        {
            Debug.Log(currentHealth);
            foreach(GameObject gameobject in Loot)
            {
                Instantiate(gameobject, this.transform);
            }

            poof.gameObject.SetActive(true);
            Destroy(this.gameObject, 1f);
        }


    }
}
