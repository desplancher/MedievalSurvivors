using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MasterClass
{
    public float enemyMoveSpeed = 3.0f;     // Velocidade do inimigo
    
    public int maxHealth = 20;              // Vida máxima do inimigo
    private int currentHealth;              // Vida atual do inimigo

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

    void EnemyMovement()
    {
        // Verifica se o jogador foi encontrado
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;      // Calcula a direção do jogador em relação ao inimigo
            direction.Normalize();                                                  // Normaliza o vetor para ter comprimento 1

            transform.Translate(direction * enemyMoveSpeed * Time.deltaTime);       // Move o inimigo na direção do jogador
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                                                    // Reduz a vida atual pelo valor de dano recebido

        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0)
        {
            EnemyDie();                                                                  // Chama a função para lidar com a morte do inimigo
        }
    }

    void EnemyDie()
    {
        // Implemente o código para lidar com a morte do inimigo aqui
        // Por exemplo, pode ser a reprodução de uma animação de morte, remover o inimigo do jogo, adicionar pontos ao jogador, etc.

        Destroy(gameObject);                                                        // Remove o GameObject do inimigo do cenário
    }
}
