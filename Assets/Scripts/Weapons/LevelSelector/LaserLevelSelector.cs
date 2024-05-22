using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLevelSelector : IWeaponLevelSelector
{
    private float _cooldownTime;
    public float cooldownTime  // read-write instance property
    {
        get => _cooldownTime;
        set => _cooldownTime = value;
    }

    private float _projectsRateMax;
    public float projectsRateMax
    {
        get => _projectsRateMax;
        set => _projectsRateMax = value;

    }

    private float _lifeTimeMax;
    public float lifeTimeMax
    {
        get => _lifeTimeMax;
        set => _lifeTimeMax = value;

    }

    private float _speed;
    public float speed
    {
        get => _speed;
        set => _speed = value;

    }

    public void Start()
    {
        LevelOne();
    }

    public void SpawnWeapon(GameObject weaponObject, Transform weaponManagerTransform, Vector3 nearestEnemy, int level, float lifeTimeMax, int damage, float range, float scale, float speed)
    {
        //SelectLevel(level);

        GameObject projectile = Transform.Instantiate(weaponObject, weaponManagerTransform.position, Quaternion.identity);
        projectile.GetComponent<Weapon>().Preapare(weaponManagerTransform, nearestEnemy, lifeTimeMax, damage, range, scale, speed);


    }

    public void SelectLevel(int level)
    {
        switch (level)
        {
            case 1:
                LevelOne();

                break;
            case 2:
                LevelTwo();
                break;
            case 3:
                LevelTree();
                break;
            case 4:
                LevelFour();
                break;
            case 5:
                LevelFive();
                break;
            default:
                break;
        }
    }

    public void LevelOne()
    {
        cooldownTime = 3;
        projectsRateMax = 1;
        lifeTimeMax = 2;
        speed = 10;
    }

    private void LevelTwo()
    {
        cooldownTime = 2;
        projectsRateMax = 0.5f;
        lifeTimeMax = 2;
        speed = 10;
    }

    private void LevelTree()
    {
        cooldownTime = 1;
        projectsRateMax = 0.25f;
        lifeTimeMax = 2;
        speed = 10;
    }

    private void LevelFour()
    {
        cooldownTime = 0.5f;
        projectsRateMax = 0.15f;
        lifeTimeMax = 2;
        speed = 10;
    }

    private void LevelFive()
    {
        cooldownTime = 0.25f;
        projectsRateMax = 0.05f;
        lifeTimeMax = 2;
        speed = 10;
    }

}

