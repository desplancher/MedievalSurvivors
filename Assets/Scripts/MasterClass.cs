using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClass : MonoBehaviour
{
    public string objectName;

    public float additionalHealthRegenration;
    public float additionalHealth;

    public int damage;
    public int defense;
    public float speed;

    public int level;
    public int maxLevel;
    public float currentExperience;
    public float maxExperience;
    public float experienceMultiplier;

    public int numberProjectsMax;
    public int actualProjects;
    public float sizeProjects;

    public int numberConjurationsMax;
    public int actualConjurations;
    public float areaConjurationsMultiplier;
    public float rangeConjurations;

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
        currentExperience += EXP;
    }

    private void levelUP(int level)
    {

    }

    //ajustar configurações dos levels uppados
    public void setLevel()
    {

    }

 

}
