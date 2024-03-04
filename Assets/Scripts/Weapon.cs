using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MasterClass
{
    public int levelWeapon;

    public float cooldownLifeTime;
    public float actualLifeTime;

    public float cooldownUnits;

    public Transform playerTransform;
    public GameObject weaponObject;

    private void Start()
    {
        cooldownLifeTime = 2;
    }
    void Update()
    {
        if (actualLifeTime <= 0)
        {
            Instantiate(weaponObject, playerTransform.position, Quaternion.identity);
        }
    }
}
