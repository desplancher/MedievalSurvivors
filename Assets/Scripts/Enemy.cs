using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AnimatedObjects
{
    private Transform playerTransform;
   

    void Start()
    {
        currentHealth = maxHealth;                                                  // Inicializa a vida atual com a vida máxima
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     // Encontre o GameObject do jogador usando a tag "Player"
    }

    void Update()
    {
        EnemyMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageInPlayer(other);
        Debug.Log(other.tag);
    }

    void EnemyMovement()
    {
        // Verifica se o jogador foi encontrado
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;      // Calcula a direção do jogador em relação ao inimigo
            direction.Normalize();                                                  // Normaliza o vetor para ter comprimento 1

            transform.Translate(direction * speed * Time.deltaTime);       // Move o inimigo na direção do jogador
        }
    }

    void DamageInPlayer(Collider2D playerCollider) // mudar para masterclass
    {
        if (playerCollider.CompareTag("Player"))
        {
            Debug.Log("Bateu2");
            playerCollider.GetComponent<Player>().TakeDamage(damage);

        }
    }
}
