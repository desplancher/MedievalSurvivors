using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDropped : MonoBehaviour
{
    public float experienceValue;

    public void Prepare(float expValue)
    {
        experienceValue = expValue;
        //Mudar a cor do objeto conforme valor da expereiencia
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
