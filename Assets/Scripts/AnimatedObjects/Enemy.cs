using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AnimatedObjects
{
    private Transform playerTransform;
    public GameObject experienceObject;

    public float experienceValue;

    void Start()
    {
        lifeSts = lifeStatus.life;
        alphaValue = 1f;
        currentHealth = maxHealth;                                                  // Inicializa a vida atual com a vida máxima
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     // Encontre o GameObject do jogador usando a tag "Player"
    }

    void Update()
    {
        EnemyMovement();

        if (lifeSts == lifeStatus.death)
        {
            DropExperience();
            lifeSts = lifeStatus.dething;

        }
        if (lifeSts == lifeStatus.dething)
        {
            Diyng(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AnimatedObjects>().TakeDamage(damage);

        }
    }

    void EnemyMovement()
    {
        if (lifeSts == lifeStatus.life) 
        {
            // Verifica se o jogador foi encontrado
            if (playerTransform != null)
            {
                Vector3 direction = playerTransform.position - transform.position;      // Calcula a direção do jogador em relação ao inimigo
                direction.Normalize();                                                  // Normaliza o vetor para ter comprimento 1

                transform.Translate(direction * speed * Time.deltaTime);       // Move o inimigo na direção do jogador
            }
        }
        
    }

    void DropExperience()
    {       
            GameObject ballOfExperience = Instantiate(experienceObject, transform.position, Quaternion.identity);
            ballOfExperience.GetComponent<ExperienceDropped>().Prepare(experienceValue);                                                 
    }
}
