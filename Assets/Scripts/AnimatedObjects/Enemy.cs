using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AnimatedObjects
{
    private Transform playerTransform;
    public GameObject experienceObject;

    public float experienceValue;
    public float experienceLifeTime;


    void Start()
    {
        currentHealth = maxHealth;                                                  // Inicializa a vida atual com a vida máxima
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     // Encontre o GameObject do jogador usando a tag "Player"
    }

    void Update()
    {
        EnemyMovement();
        EnemyDie();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GiveDamage(other, "Player");
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

    void EnemyDie()
    {
        // Verifica se o inimigo ficou sem vida
        if (currentHealth <= 0)
        {
            GameObject ballOfExperience = Instantiate(experienceObject, transform.position, Quaternion.identity);
            ballOfExperience.GetComponent<ExperienceDropped>().Prepare(experienceValue);
            AnimatedObjectDie();                                                                  // Chama a função para lidar com a morte do inimigo
            
        }
    }
}
