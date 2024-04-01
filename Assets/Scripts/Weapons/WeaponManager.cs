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
    //public AllWeapons nameWeapon;

    //public GameObject targetObject;

    private GameObject[] allEnemyes;
    private GameObject nearestEnemy;
    private float distanteToNearestEnemy;


    public float cooldownTime;
    private float actualCooldown;

    public float lifeTimeMax;

    public float projectsRateMax;
    private float actualProjecstRate;

    public IWeaponLevelSelector cLevel;
    

    public GameObject weaponObject;

    public WeaponStatus weaponStatus = WeaponStatus.Restarting;

    private void Start()
    {
        cLevel = new FireBallLevelSelector();
    }
    void Update()
    {
        WeaponStatusSelector();
    }

    void WaitingNextFire()
    {
        actualProjecstRate -= Time.deltaTime;

        if (actualProjecstRate <= 0)
        {
            weaponStatus = WeaponStatus.Firing;
        }
    }

    /// <summary>
    /// Cria / Instancia o Prefab da arma
    /// </summary>
    void Firing()
    {

        FindNearestEnemy();

        cLevel.SelectLevel(weaponObject, gameObject.transform, nearestEnemy, level, lifeTimeMax, damage, rangeConjurations, rangeConjurations, speed);

        actualProjects--;
        actualProjecstRate = projectsRateMax;

        weaponStatus = (actualProjects <= 0) ? WeaponStatus.Restarting : WeaponStatus.BetweenFire;
    }

    /// <summary>
    /// Reinicia os Atributos inicias da Arma.
    /// </summary>
    void RestartingWeapon()
    {
        weaponStatus = WeaponStatus.Cooldown;
        actualCooldown = cooldownTime;
        actualProjecstRate = projectsRateMax;
        actualProjects = numberProjectsMax;
    }

    /// <summary>
    /// Verifica o Status Atual da Arma e executa a fun��o correspondente.
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


}
