using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyMoveSpeed = 3.0f;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        // Encontre o GameObject do jogador usando a tag "Player"
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // Verifique se o jogador foi encontrado
        if (playerTransform != null)
        {
            // Calcule a direção do jogador em relação ao inimigo
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize(); // Normaliza o vetor para ter comprimento 1

            // Mova o inimigo na direção do jogador
            transform.Translate(direction * enemyMoveSpeed * Time.deltaTime);
        }
    }
}
