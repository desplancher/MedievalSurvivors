using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Shuriken : WeaponManager
{
    void Update()
    {
        if (transform != null)
        {
            transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
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
