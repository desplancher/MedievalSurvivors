using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWeapon : MonoBehaviour
{
    public int damage = 10;
    public float rotationSpeed = 100.0f;
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageInEnemy(other);
    }

    void DamageInEnemy(Collider2D enemyCollider)
    {
        if (enemyCollider.CompareTag("Enemy"))
        {
            
            enemyCollider.GetComponent<Enemy>().TakeDamage(damage);

        }
    }
}