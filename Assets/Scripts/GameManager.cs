using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    


    public GameObject[] enemyPrefabs;   // Array de prefabs de inimigos
    public Camera gameCamera;           // Referencia a camera
    public float spawnInterval = 1.0f;  // Intervalo em segundos entre o surgimento de inimigos
    

    private float nextSpawnTime; // Momento do próximo surgimento de inimigo
    public float distanceSpawn;

    public Player playerObject;
    public UpgradeGroup levelUpPanelGroup;

    public int currentLevel;
    public int lastLevel;

    public int maxWeapons;
    public int currentWeapons;

    public float timeGame;
    public float timeFirstBoss;
    public bool bossSpawned;

    public GameObject bossPrefab;

    public TMP_Text timeText;

    private void Awake()
    {
        CreateCharacter();
    }

    void Start()
    {
        
        
        nextSpawnTime = Time.time + spawnInterval;  // Defina o próximo momento de surgimento para o início do jogo
        //currentLevel = playerObject.level;
        //lastLevel = currentLevel;
        currentWeapons = 1;
        
    }

    void Update()
    {
        timeGame += Time.deltaTime;
        timeText.text = (int)timeGame + "";

        SpawnRandomEnemy();

        if (Time.timeSinceLevelLoad >= timeFirstBoss && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true; // Garante que o boss só será instanciado uma vez
        }



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
    }

    Vector3 RandomPosition(Vector3 cameraPosition)
    {
        float cameraHeight = 2f * gameCamera.orthographicSize; // Altura da Camera
        float cameraWidth = cameraHeight * gameCamera.aspect;  // Largura da Camera

        float cameraX = cameraPosition.x;
        float cameraY = cameraPosition.y;

        // Gere posições aleatórias para o surgimento dos inimigos

        float randomX = UnityEngine.Random.Range(cameraX - cameraWidth / 2f, cameraX + cameraWidth / 2f);      // Faixa X do mapa
        float randomY = UnityEngine.Random.Range(cameraY - cameraHeight / 2f, cameraY + cameraHeight / 2f);    // Faixa Y do mapa
                                                                                                               // 
        return new Vector3(randomX, randomY, 0);
    }

    void SpawnRandomEnemy()
    {

        // Verifique se é hora de criar um inimigo
        if (Time.time >= nextSpawnTime)
        {
            // Escolha aleatoriamente um prefab de inimigo do array
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

           
            Vector3 cameraPosition = gameCamera.transform.position; 
            Vector3 randomVector = RandomPosition(cameraPosition);


            // Se o valor aleatorio de X e o valor aleatorio de Y estiverem fora do raio da distancia de Spawn, a condicao é satisfeita
            if (((randomVector.x <= (cameraPosition.x - distanceSpawn) || randomVector.x >= (cameraPosition.x + distanceSpawn)) && 
                 (randomVector.y <= (cameraPosition.y - distanceSpawn) || randomVector.y >= (cameraPosition.y + distanceSpawn))))
            {

                Vector3 spawnPosition = new Vector3(randomVector.x, randomVector.y, 0);

                // Crie um novo inimigo na posição aleatória
                Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
                // Atualize o próximo momento de surgimento
                nextSpawnTime = Time.time + spawnInterval;
            } else
            {
                nextSpawnTime = Time.time;
            }
        }  
    }

    void CreateCharacter()
    {
        GameObject character;
        
        switch (MessengerClass.CharacterSelected.ToLower())
        {
            
            case "warrior":
                character = Resources.Load<GameObject>("Prefabs/Characters/Warrior");
                break;
            case "mage":
                character = Resources.Load<GameObject>("Prefabs/Characters/Mage");
                break;
            case "orc":
                character = Resources.Load<GameObject>("Prefabs/Characters/Orc");            
                break;
            default:
                character = Resources.Load<GameObject>("Prefabs/Characters/Warrior");
                break;
        }
        GameObject hero = Instantiate(character);
        gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        gameCamera.transform.SetParent(hero.transform);
        hero.name = MessengerClass.CharacterSelected;
        playerObject = hero.GetComponent<Player>();
    }

    void SpawnBoss()
    {
        Vector3 cameraPosition = gameCamera.transform.position;
        Vector3 randomVector = RandomPosition(cameraPosition);


        // Instancia o boss no ponto de spawn especificado
        Instantiate(bossPrefab, randomVector * 2, Quaternion.identity);

        Debug.Log(Time.timeSinceLevelLoad);

    }
}
