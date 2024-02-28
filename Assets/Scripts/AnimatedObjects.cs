using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObjects : MasterClass
{
    public float maxHealth;
    public float currentHealth;
    public float healthRegenration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                                                    // Reduz a vida atual pelo valor de dano recebido

        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0 && isEnemy == true)
        {
            AnimatedObjectDie();                                                                  // Chama a fun��o para lidar com a morte do inimigo
        }
    }
    void AnimatedObjectDie()
    {
        // Implemente o c�digo para lidar com a morte do inimigo aqui
        // Por exemplo, pode ser a reprodu��o de uma anima��o de morte, remover o inimigo do jogo, adicionar pontos ao jogador, etc.

        Destroy(gameObject);                                                        // Remove o GameObject do inimigo do cen�rio
    }
}
