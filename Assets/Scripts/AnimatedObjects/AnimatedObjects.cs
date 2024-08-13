using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum lifeStatus
{
    life,
    death,
    dying,
    destroy
}

public class AnimatedObjects : MasterClass
{
    public float maxHealth;
    public float currentHealth;
    public float healthRegenration;
    public Image healthBar;

    public SpriteRenderer spriteAnimObject;
    public float alphaValue;
    public lifeStatus lifeSts;
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                                                    // Reduz a vida atual pelo valor de dano recebido
        UpdateHealth();
    }

    public void Diyng()
    {
        alphaValue -= 5f * Time.deltaTime;
        spriteAnimObject.color = new Color(1, 1, 1, alphaValue);

        if(alphaValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealth()
    {
        
        if(healthBar  != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth <= 0)
        {
            lifeSts = lifeStatus.death;
        }
    }
}
