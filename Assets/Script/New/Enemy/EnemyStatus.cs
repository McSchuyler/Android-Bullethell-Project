using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    public float baseHealth;
    public string enemyTag;

    private float currentHealth;

    public void Start()
    {
        currentHealth = baseHealth;
    }

    public void Damage(float i)
    {
        currentHealth -= i;

        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            ObjectPooler.instance.ReturnToPool(enemyTag, gameObject);
        }
    }
}
