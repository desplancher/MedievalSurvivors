using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : AnimatedObjects
{
    public Image healthBar;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        PlayerMovement();  
        PlayerTakeDamage();
        PlayerHeal();
        PlayerDeath();
    }

    void PlayerMovement()
    {
        // Obtém as entradas de movimento horizontal e vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // Move o jogador
        transform.Translate(movement);
    }

    public void PlayerTakeDamage()
    {
        healthBar.fillAmount = currentHealth / 100f;
    }

    public void PlayerHeal()
    {
        currentHealth += healthRegenration * Time.fixedDeltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        healthBar.fillAmount = currentHealth / 100f;
    }

    public void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene"); //recarrega a cena
        }
    }
}
