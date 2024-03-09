using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDropped : MonoBehaviour
{
    public float experienceValue;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Prepare(float expValue, float life)
    {
        experienceValue = expValue;
        //lifeTime = life;
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public float GiveExperience()
    {
        return experienceValue;
    }
  
    /*public void LifeUpdate()
    {
        lifeTime -= Time.deltaTime;
     

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }*/
}
