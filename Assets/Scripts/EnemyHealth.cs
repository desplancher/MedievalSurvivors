using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; // Vida m�xima do inimigo
    private int currentHealth;   // Vida atual do inimigo

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida m�xima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor de dano recebido

        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0)
        {
            Die(); // Chama a fun��o para lidar com a morte do inimigo
        }
    }

    void Die()
    {
        // Implemente o c�digo para lidar com a morte do inimigo aqui
        // Por exemplo, pode ser a reprodu��o de uma anima��o de morte, remover o inimigo do jogo, adicionar pontos ao jogador, etc.

        Destroy(gameObject); // Remove o GameObject do inimigo do cen�rio
    }
}