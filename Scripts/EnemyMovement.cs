using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour

{
    public float moveSpeed = 5f; // Speed at which the enemy moves forward

    private void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        // Move the enemy forward in the direction it is facing
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}

