using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 50;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank;
        bank = FindObjectOfType<Bank>();

        if (bank == null) 
        { 
            return false;
        }

        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdrawal(towerCost);
            return true;
        }

        return false; //safeguard if all other functions and bools fail
    }
}
