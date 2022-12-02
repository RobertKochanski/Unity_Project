using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float healthPoints = 100f;
    [SerializeField]
    private TextMeshProUGUI healthDisplay;

    private void Update()
    {
        DisplayHealth();
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public float CureDamage(float heal)
    {
        if (healthPoints >= 100)
        {
            return -1;
        }

        if (healthPoints + heal <= 100)
        {
            healthPoints += heal;
        }
        else if (healthPoints + heal > 100)
        {
            healthPoints = 100;
        }

        return healthPoints;
    }

    private void DisplayHealth()
    {
        healthDisplay.text = $"HP:{healthPoints}/100";
        if (healthPoints > 50)
        {
            healthDisplay.color = Color.green;
        }
        if (healthPoints <= 50)
        {
            healthDisplay.color = Color.yellow;
        }
        if (healthPoints <= 20)
        {
            healthDisplay.color = Color.red;
        }
    }
}
