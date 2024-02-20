using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MasterClass
{
    public int maxHealth = 100;
    public int currentHealth;
    public float healthRegenration;

    public int defense;

    public float speed = 5.0f; // Velocidade do jogador

    public int numberProjects;
    public float sizeProjects;

    public int numberConjurations;
    public float areaConjurationsMultiplier;



    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        PlayerMovement();
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
}
