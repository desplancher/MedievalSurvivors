using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ExpStatus
{
    
    InProgress,
    ChangingLevel,
    WaitingSelectionUpgrade,
    LevelUP
}

public class Player : AnimatedObjects
{
    public ExpStatus experienceStatus;
    public Image expBar;
    public float excedentExperience;

    void Start()
    {
        experienceStatus = ExpStatus.InProgress;
        currentHealth = maxHealth;
        lifeSts = lifeStatus.life;
    }

    void Update()
    {

        PlayerMovement();  
        PlayerHeal();
        PlayerDeath();
        ExperienceStatusSelector();


    }

    void PlayerMovement()
    {
        if (lifeSts == lifeStatus.life)
        {
            // Obtém as entradas de movimento horizontal e vertical
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calcula o vetor de movimento
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

            // Move o jogador de acordo com os dados do vetor
            transform.Translate(movement);
        }
    }

    

    public void PlayerHeal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegenration * Time.deltaTime;

            UpdateHealth();
        }
        
    }

    public void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene"); //recarrega a cena
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Exp"))
        {
            addEXP(other.GetComponent<ExperienceDropped>().experienceValue);
            other.GetComponent<ExperienceDropped>().Destroy();
        }

    }


    public void PlayerLevelUp()
    {
        level++;
        maxExperience *= 2;
        currentExperience = excedentExperience;
        excedentExperience = 0;
        currentHealth = maxHealth;
        experienceStatus = ExpStatus.InProgress;
        
    }

    void ExperienceStatusSelector()
    {
        switch (experienceStatus)
        {
            case ExpStatus.InProgress:
                CheckExp();
                break;

            case ExpStatus.LevelUP:
                PlayerLevelUp();
                break;
            
            default:
                break;
        }
    }

    public void CheckExp()
    {
        expBar.fillAmount = currentExperience / maxExperience;
        if (currentExperience >= maxExperience)
        {
            experienceStatus = ExpStatus.ChangingLevel;
        }

    }

    public void CreateWeaponManager(string weaponName)
    {
        GameObject weaponsManagersGroup = GameObject.Find("WeaponsManagers");

       

        switch (weaponName)
        {
            case "FireBall":
                GameObject fireBall = Resources.Load<GameObject>("Prefabs/WeaponsManagers/" + weaponName + "Manager");
                Instantiate(fireBall, weaponsManagersGroup.transform);
                break;
            case "Shuriken":
                GameObject shuriken = Resources.Load<GameObject>("Prefabs/WeaponsManagers/" + weaponName + "Manager");
                Instantiate(shuriken, weaponsManagersGroup.transform);
                break;
            case "Laser":
                GameObject laser = Resources.Load<GameObject>("Prefabs/WeaponsManagers/" + weaponName + "Manager");
                Instantiate(laser, weaponsManagersGroup.transform);
                break;
        }
    }

}
