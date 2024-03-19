using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    List<int> listNumbers;


    public GameObject[] enemyPrefabs;   // Array de prefabs de inimigos
    public Camera gameCamera;           // Referencia a camera
    public float spawnInterval = 1.0f;  // Intervalo em segundos entre o surgimento de inimigos
    

    private float nextSpawnTime; // Momento do próximo surgimento de inimigo
    public float distanceSpawn;

    public Player playerObject;
    public GameObject levelUpPanel;

    public int currentLevel;
    public int lastLevel;

    public int maxWeapons;
    public int currentWeapons;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;  // Defina o próximo momento de surgimento para o início do jogo
        currentLevel = playerObject.level;
        lastLevel = currentLevel;
        currentWeapons = 1;
        listNumbers = new List<int>();
    }

    void Update()
    {
        SpawnRandomEnemy();

        currentLevel = playerObject.level;
        if (currentLevel != lastLevel ) 
        {
            OpenPanelLevelUp();
            lastLevel = currentLevel;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(/*currentWeapons < maxWeapons*/false)
            {
                SortingAll();
            }
            else
            {
                SortingWithMaxWeapons();
                
            }
        }
    }

    void SpawnRandomEnemy()
    {

        // Verifique se é hora de criar um inimigo
        if (Time.time >= nextSpawnTime)
        {
            // Escolha aleatoriamente um prefab de inimigo do array
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

            // Obtém a posição atual da câmera
            Vector3 cameraPosition = gameCamera.transform.position;

            float cameraHeight = 2f * gameCamera.orthographicSize; // Altura da Camera
            float cameraWidth = cameraHeight * gameCamera.aspect;  // Largura da Camera

            float cameraX = cameraPosition.x;
            float cameraY = cameraPosition.y;

            // Gere posições aleatórias para o surgimento dos inimigos

            float randomX = UnityEngine.Random.Range(cameraX - cameraWidth / 2f, cameraX + cameraWidth / 2f);      // Faixa X do mapa
            float randomY = UnityEngine.Random.Range(cameraY - cameraHeight / 2f, cameraY + cameraHeight / 2f);    // Faixa Y do mapa     


            // Se o valor aleatorio de X e o valor aleatorio de Y estiverem fora do raio da distancia de Spawn, a condicao é satisfeita
            if (((randomX <= (cameraX - distanceSpawn) || randomX >= (cameraX + distanceSpawn)) && 
                 (randomY <= (cameraY - distanceSpawn) || randomY >= (cameraY + distanceSpawn))))
            {
                //Debug.Log("Camera W: " + cameraWidth / 2f + ", Camera H: " + cameraHeight / 2f);
                //Debug.Log("Camera X: " + cameraX + ", Camera Y: " + cameraY);
               // Debug.Log("Random X: " + randomX + ", Random Y: " + randomY);


                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

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

    void OpenPanelLevelUp()
    {
        levelUpPanel.SetActive(true);
        Time.timeScale = 0;
        //SortingWithMaxWeapons();
        //PrepareLevelUpPanel();
    }

    public void EvolveWeapon1()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void EvolveWeapon2()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void EvolveWeapon3()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void EvolveWeapon4()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SortingAll()
    {
        
        listNumbers.Clear();

        int WeaponsCount = Enum.GetNames(typeof(AllWeapons)).Length;

        //int randomWeapon = UnityEngine.Random.Range(0, WeaponsCount);

        //Debug.Log((AllWeapons)randomWeapon);

        var rand = new System.Random();

        do
        {
            int numbers = rand.Next(0, WeaponsCount);
            if (!listNumbers.Contains(numbers))
            {
                listNumbers.Add(numbers);
            }
        } while (listNumbers.Count < 4);

        //Debug.Log(listNumbers[0]);
        //Debug.Log(listNumbers[1]);
       // Debug.Log(listNumbers[2]);
        //Debug.Log(listNumbers[3]);
        
    }

    public void SortingWithMaxWeapons()
    {
        listNumbers.Clear();

        WeaponManager[] WeaponsInPlayer = playerObject.GetComponentsInChildren<WeaponManager>();
        
        for(int i = 0; i < WeaponsInPlayer.Length; i++)
        {
            if (WeaponsInPlayer[i].level < WeaponsInPlayer[i].maxLevel)
            {
                listNumbers.Add((int)WeaponsInPlayer[i].nameWeapon);
            }
        }

        listNumbers.Sort();

        //Debug.Log(listNumbers[0]);
        //Debug.Log(listNumbers[1]);
        
    }

    public void PrepareLevelUpPanel()
    {
        for (int i = 1; i < 5; i++)
        {
            GameObject.Find("ButtonUpgrade" + i).SetActive(false);
            Debug.Log("ButtonUpgrade" + i);
        }

        int limit = (listNumbers.Count > 4)? 4: listNumbers.Count;

        for (int i = 0;i < limit;i++)
        {
            GameObject.Find("ButtonUpgrade" + (i+1)).SetActive(true);
        }


    }
}
