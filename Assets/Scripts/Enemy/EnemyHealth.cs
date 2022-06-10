using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;

    [Tooltip("Adds amount to maxHealth when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHealth = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            enemy.EnemyDeathReward();
            maxHealth += difficultyRamp;
        }
    }
}
