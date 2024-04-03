using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AllWeapons
{
    Shuriken,
    Fireball,
    Arma3,
    Arma4,
    Arma5,
    Arma6,
    Arma7
}

public enum WeaponStatus
{
    Cooldown,
    BetweenFire,
    Firing,
    Restarting
}

public class WeaponManager : MasterClass
{
    public GameObject[] allEnemyes;
    public GameObject nearestEnemy;
    public float distanteToNearestEnemy;

    private float cooldownTime;
    private float actualCooldown;

    public float lifeTimeMax;

    private float projectsRateMax;
    private float actualProjectsRate;

    private IWeaponLevelSelector cLevel;

    public GameObject weaponObject;

    private WeaponStatus weaponStatus = WeaponStatus.Restarting;

    private void Start()
    {
        WeaponLevelSelector();
        LevelSelectorStatus();
    }

    void Update()
    {
        WeaponStatusSelector();
        FindNearestEnemy();
    }

    void WaitingNextFire()
    {
        actualProjectsRate -= Time.deltaTime;

        if (actualProjectsRate <= 0)
        {
            weaponStatus = WeaponStatus.Firing;
        }
    }

    void Firing()
    {
        cLevel.SpawnWeapon(weaponObject, gameObject.transform, nearestEnemy, level, lifeTimeMax, damage, rangeConjurations, rangeConjurations, speed);
        LevelSelectorStatus();

        actualProjects--;
        actualProjectsRate = projectsRateMax;

        weaponStatus = (actualProjects <= 0) ? WeaponStatus.Restarting : WeaponStatus.BetweenFire;
    }

    /// <summary>
    /// Reinicia os Atributos iniciais da Arma.
    /// </summary>
    void RestartingWeapon()
    {
        weaponStatus = WeaponStatus.Cooldown;
        actualCooldown = cooldownTime;
        actualProjectsRate = projectsRateMax;
        actualProjects = numberProjectsMax;
    }

    /// <summary>
    /// Verifica o Status Atual da Arma e executa a função correspondente.
    /// </summary>
    void WeaponStatusSelector()
    {
        switch (weaponStatus)
        {
            case WeaponStatus.Cooldown:
                if (actualCooldown > 0)
                {
                    actualCooldown -= Time.deltaTime;
                }
                else
                {
                    weaponStatus = WeaponStatus.Firing;
                }
                break;
            case WeaponStatus.BetweenFire:
                WaitingNextFire();
                break;
            case WeaponStatus.Firing:
                Firing();
                break;
            case WeaponStatus.Restarting:
                RestartingWeapon();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Encontra o GameObject com a tag "Enemy" mais proximo do Player.
    /// </summary>
    void FindNearestEnemy()
    {
        allEnemyes = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemyes.Length > 0)
        {
            nearestEnemy = allEnemyes[0];
            distanteToNearestEnemy = Vector2.Distance(transform.position, nearestEnemy.transform.position);
        }
        else
        {
            weaponStatus = WeaponStatus.Restarting;
        }

        for (int i = 1; i < allEnemyes.Length; i++)
        {
            float distanceToCurrentEnemy = Vector2.Distance(transform.position, allEnemyes[i].transform.position);

            if (distanceToCurrentEnemy < distanteToNearestEnemy)
            {
                nearestEnemy = allEnemyes[i];
                distanteToNearestEnemy = distanceToCurrentEnemy;
            }
        }
    }

    void WeaponLevelSelector()
    {
        switch (objectName)
        {
            case "FireBall":
                cLevel = gameObject.AddComponent<FireBallLevelSelector>();
                break;
            case "Shuriken":
                //cLevel = new FireBallLevelSelector();  // Comentado, pois causa erro
                break;
        }
    }

    void LevelSelectorStatus()
    {
        cooldownTime = cLevel.cooldownTime;
        projectsRateMax = cLevel.projectsRateMax;
        lifeTimeMax = cLevel.lifeTimeMax;
    }
}
