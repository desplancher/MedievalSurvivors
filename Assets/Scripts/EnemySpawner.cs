using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de inimigos
    public float spawnInterval = 3.0f; // Intervalo em segundos entre o surgimento de inimigos

    private float nextSpawnTime; // Momento do próximo surgimento de inimigo

    void Start()
    {
        // Defina o próximo momento de surgimento para o início do jogo
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Verifique se é hora de criar um inimigo
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemy();
            // Atualize o próximo momento de surgimento
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnRandomEnemy()
    {
        // Escolha aleatoriamente um prefab de inimigo do array
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

        // Gere posições aleatórias para o surgimento dos inimigos
        float randomX = Random.Range(-10f, 10f); // Faixa X do mapa
        float randomY = Random.Range(-5f, 5f); // Faixa Y do mapa

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        // Crie um novo inimigo na posição aleatória
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}