using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Shuriken : Weapon
{
    void Update()
    {
        if (playerTransform != null)
        {
            transform.RotateAround(playerTransform.position, Vector3.forward, speed * Time.deltaTime);
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
