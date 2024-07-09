using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    


    public GameObject[] enemyPrefabs;   // Array de prefabs de inimigos
    public Camera gameCamera;           // Referencia a camera
    public float spawnInterval = 1.0f;  // Intervalo em segundos entre o surgimento de inimigos
    

    private float nextSpawnTime; // Momento do pr�ximo surgimento de inimigo
    public float distanceSpawn;

    public Player playerObject;
    public UpgradeGroup levelUpPanelGroup;

    public int currentLevel;
    public int lastLevel;

    public int maxWeapons;
    public int currentWeapons;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;  // Defina o pr�ximo momento de surgimento para o in�cio do jogo
        //currentLevel = playerObject.level;
        //lastLevel = currentLevel;
        currentWeapons = 1;
        
    }

    void Update()
    {
        SpawnRandomEnemy();

        
        if (playerObject.experienceStatus == ExpStatus.ChangingLevel) 
        {

            playerObject.excedentExperience = playerObject.currentExperience - playerObject.maxExperience;
            

            if (currentWeapons < maxWeapons)
            {
                levelUpPanelGroup.OpenPanelNormal();

            }
            else
            {
                levelUpPanelGroup.OpenPanelFullWeapons(playerObject.GetComponentsInChildren<WeaponManager>());

            }

            playerObject.experienceStatus = ExpStatus.WaitingSelectionUpgrade;

            //lastLevel = currentLevel;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentWeapons < maxWeapons)
            {
                levelUpPanelGroup.OpenPanelNormal();

            }
            else
            {
                levelUpPanelGroup.OpenPanelFullWeapons(playerObject.GetComponentsInChildren<WeaponManager>());

            }
        }
    }

    void SpawnRandomEnemy()
    {

        // Verifique se � hora de criar um inimigo
        if (Time.time >= nextSpawnTime)
        {
            // Escolha aleatoriamente um prefab de inimigo do array
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

            // Obt�m a posi��o atual da c�mera
            Vector3 cameraPosition = gameCamera.transform.position;

            float cameraHeight = 2f * gameCamera.orthographicSize; // Altura da Camera
            float cameraWidth = cameraHeight * gameCamera.aspect;  // Largura da Camera

            float cameraX = cameraPosition.x;
            float cameraY = cameraPosition.y;

            // Gere posi��es aleat�rias para o surgimento dos inimigos

            float randomX = UnityEngine.Random.Range(cameraX - cameraWidth / 2f, cameraX + cameraWidth / 2f);      // Faixa X do mapa
            float randomY = UnityEngine.Random.Range(cameraY - cameraHeight / 2f, cameraY + cameraHeight / 2f);    // Faixa Y do mapa     


            // Se o valor aleatorio de X e o valor aleatorio de Y estiverem fora do raio da distancia de Spawn, a condicao � satisfeita
            if (((randomX <= (cameraX - distanceSpawn) || randomX >= (cameraX + distanceSpawn)) && 
                 (randomY <= (cameraY - distanceSpawn) || randomY >= (cameraY + distanceSpawn))))
            {
                //Debug.Log("Camera W: " + cameraWidth / 2f + ", Camera H: " + cameraHeight / 2f);
                //Debug.Log("Camera X: " + cameraX + ", Camera Y: " + cameraY);
               // Debug.Log("Random X: " + randomX + ", Random Y: " + randomY);


                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

                // Crie um novo inimigo na posi��o aleat�ria
                Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
                
                // Atualize o pr�ximo momento de surgimento
                nextSpawnTime = Time.time + spawnInterval;
            } else
            {
                nextSpawnTime = Time.time;
            }
        }  
    }
}
