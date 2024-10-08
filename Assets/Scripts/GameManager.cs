using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



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

    public float timeGame;
    public float timeFirstBoss;
    public bool bossSpawned;

    public GameObject bossPrefab;

    public TMP_Text timeText;

    public TMP_Text fireBallLevel;
    public TMP_Text laserLevel;
    public TMP_Text shurikenLevel;

    bool pause;

    private void Awake()
    {
        CreateCharacter();
    }

    void Start()
    {
        pause = false;
        
        nextSpawnTime = Time.time + spawnInterval;  // Defina o pr�ximo momento de surgimento para o in�cio do jogo
        //currentLevel = playerObject.level;
        //lastLevel = currentLevel;
        currentWeapons = 1;
        UpdateHud();
    }

    void Update()
    {
        timeGame += Time.deltaTime;
        timeText.text = (int)timeGame + "";

        SpawnRandomEnemy();

        if (Time.timeSinceLevelLoad >= timeFirstBoss && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true; // Garante que o boss s� ser� instanciado uma vez
        } else if(Time.timeSinceLevelLoad >= 160f)
        {
            MenuScript menuScript = new MenuScript();
            menuScript.ChangeSceneTo("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.P) && pause == false) 
        {
            Time.timeScale = 0;
            pause = true;
        } else if (Input.GetKeyDown(KeyCode.P) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
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

        // Gere posi��es aleat�rias para o surgimento dos inimigos

        float randomX = UnityEngine.Random.Range(cameraX - cameraWidth / 2f, cameraX + cameraWidth / 2f);      // Faixa X do mapa
        float randomY = UnityEngine.Random.Range(cameraY - cameraHeight / 2f, cameraY + cameraHeight / 2f);    // Faixa Y do mapa
                                                                                                               // 
        return new Vector3(randomX, randomY, 0);
    }

    void SpawnRandomEnemy()
    {

        // Verifique se � hora de criar um inimigo
        if (Time.time >= nextSpawnTime)
        {
            // Escolha aleatoriamente um prefab de inimigo do array
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

           
            Vector3 cameraPosition = gameCamera.transform.position; 
            Vector3 randomVector = RandomPosition(cameraPosition);


            // Se o valor aleatorio de X e o valor aleatorio de Y estiverem fora do raio da distancia de Spawn, a condicao � satisfeita
            if (((randomVector.x <= (cameraPosition.x - distanceSpawn) || randomVector.x >= (cameraPosition.x + distanceSpawn)) && 
                 (randomVector.y <= (cameraPosition.y - distanceSpawn) || randomVector.y >= (cameraPosition.y + distanceSpawn))))
            {

                Vector3 spawnPosition = new Vector3(randomVector.x, randomVector.y, 0);

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

    public void UpdateHud()
    {
        GameObject fireManager = GameObject.Find("FireBallManager");
        if (fireManager != null) 
            {
            fireBallLevel.text = fireManager.GetComponent<WeaponManager>().level + "";
        }
        else
        {
            fireBallLevel.text = "0";
        }

        GameObject shurikenManager = GameObject.Find("ShurikenManager");
        if (shurikenManager != null)
        {
            shurikenLevel.text = shurikenManager.GetComponent<WeaponManager>().level + "";
        }
        else
        {
            shurikenLevel.text = "0";
        }

        GameObject laserManager = GameObject.Find("LaserManager");
        if (laserManager != null)
        {
            laserLevel.text = laserManager.GetComponent<WeaponManager>().level + "";
        }
        else
        {
            laserLevel.text = "0";
        }
    }

}
