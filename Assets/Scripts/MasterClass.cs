using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClass : MonoBehaviour
{
    public int level = 1;
    public float actualExperience;
    public float maxExperience;
    public float experienceMultiplier;

    public int damage;

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
