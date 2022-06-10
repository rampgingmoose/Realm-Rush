using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldReduction = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void EnemyDeathReward()
    {
        if (bank == null) { return; }

        bank.Deposit(goldReward);
    }

    public void EnemyVictoryDeduction()
    {
        if (bank == null) { return; }

        bank.Withdrawal(goldReduction);
    }
}
