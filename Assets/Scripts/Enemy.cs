using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MasterClass
{
    public float enemyMoveSpeed = 3.0f;     // Velocidade do inimigo
    
    public int maxHealth = 20;              // Vida m�xima do inimigo
    private int currentHealth;              // Vida atual do inimigo

    private Transform playerTransform;
   

    void Start()
    {
        currentHealth = maxHealth;                                                  // Inicializa a vida atual com a vida m�xima
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     // Encontre o GameObject do jogador usando a tag "Player"
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // Verifica se o jogador foi encontrado
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;      // Calcula a dire��o do jogador em rela��o ao inimigo
            direction.Normalize();                                                  // Normaliza o vetor para ter comprimento 1

            transform.Translate(direction * enemyMoveSpeed * Time.deltaTime);       // Move o inimigo na dire��o do jogador
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                                                    // Reduz a vida atual pelo valor de dano recebido

        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0)
        {
            EnemyDie();                                                                  // Chama a fun��o para lidar com a morte do inimigo
        }
    }

    void EnemyDie()
    {
        // Implemente o c�digo para lidar com a morte do inimigo aqui
        // Por exemplo, pode ser a reprodu��o de uma anima��o de morte, remover o inimigo do jogo, adicionar pontos ao jogador, etc.

        Destroy(gameObject);                                                        // Remove o GameObject do inimigo do cen�rio
    }
}
