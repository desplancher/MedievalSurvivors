using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ExpStatus
{
    LevelUp,
    InProgress
}

public class Player : AnimatedObjects
{
    public ExpStatus experienceStatus;
    
    public Image healthBar;
    public Image expBar;

    public float excedentExperience;

    void Start()
    {
        experienceStatus = ExpStatus.InProgress;
        currentHealth = maxHealth;
        
    }

    void Update()
    {

        PlayerMovement();  
        PlayerTakeDamage();
        PlayerHeal();
        PlayerDeath();

        ExperienceStatusSelector();


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

    public void PlayerTakeDamage()
    {
        healthBar.fillAmount = currentHealth / 100f;
    }

    public void PlayerHeal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegenration * Time.fixedDeltaTime;
            //currentHealth = Mathf.Clamp(currentHealth, 0, 100);

            healthBar.fillAmount = currentHealth / 100f;
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
            addEXP(other.GetComponent<ExperienceDropped>().GiveExperience());
            other.GetComponent<ExperienceDropped>().Destroy();
        }

    }

    public void PlayerTakeExperience()
    {
        expBar.fillAmount = currentExperience / maxExperience;
        
        if (currentExperience >= maxExperience)
        {
            excedentExperience = currentExperience - maxExperience;
            experienceStatus = ExpStatus.LevelUp;
        }
    }

    public void PlayerLevelUp()
    {
        level++;
        maxExperience *= 2;
        currentExperience = excedentExperience;
        experienceStatus = ExpStatus.InProgress;
        
    }

    void ExperienceStatusSelector()
    {
        switch (experienceStatus)
        {
            case ExpStatus.LevelUp:
                PlayerLevelUp();
                Debug.Log("Level UP !!");
                break;
            case ExpStatus.InProgress:
                
                PlayerTakeExperience();
                break;
            default:
                break;
        }
    }


}
