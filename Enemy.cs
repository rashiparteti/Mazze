using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 30f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health decreased. Current health: " + health);

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
