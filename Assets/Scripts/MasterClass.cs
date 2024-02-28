using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClass : MonoBehaviour
{
    public float additionalHealthRegenration;
    public float additionalHealth;

    public int damage;
    public int defense;
    public int speed;

    public int level;
    public float actualExperience;
    public float maxExperience;
    public float experienceMultiplier;

    public int numberProjects;
    public float sizeProjects;

    public int numberConjurations;
    public float areaConjurationsMultiplier;

    public bool isEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addEXP(float EXP)
    {
        actualExperience += EXP;
    }

    private void levelUP(int level)
    {

    }

    //ajustar configurações dos levels uppados
    public void setLevel()
    {

    }

}
