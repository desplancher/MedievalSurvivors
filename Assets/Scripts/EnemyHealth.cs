using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; // Vida máxima do inimigo
    private int currentHealth;   // Vida atual do inimigo

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor de dano recebido

        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0)
        {
            Die(); // Chama a função para lidar com a morte do inimigo
        }
    }

    void Die()
    {
        // Implemente o código para lidar com a morte do inimigo aqui
        // Por exemplo, pode ser a reprodução de uma animação de morte, remover o inimigo do jogo, adicionar pontos ao jogador, etc.

        Destroy(gameObject); // Remove o GameObject do inimigo do cenário
    }
}