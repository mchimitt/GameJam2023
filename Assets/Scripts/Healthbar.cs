using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [SerializeField] private Image _healthBar;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / maxHealth;
    }
}
