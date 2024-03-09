using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStatus
{
    Cooldown,
    BetweenFire,
    Firing,
    Restarting
}

public class WeaponManager : MasterClass
{
    public GameObject targetObject;
    public GameObject[] allEnemyes;
    public GameObject nearestEnemy;
    public float distanteToNearestEnemy;


    public float cooldownTime;
    public float actualCooldown;
    public float lifeTimeMax;
    public float projectsRateMax;
    public float actualProjecstRate;

    public GameObject weaponObject;

    public WeaponStatus weaponStatus = WeaponStatus.Restarting;
    private void Start()
    {
        
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
        switch (level)
        {
            case 0:
                Debug.Log("Atira");
                break;
            case 1:
                //Vector3 newPosition = new Vector3((float)(transform.position.x + 0.1), (float)(transform.position.y + 0.1), 0);

                GameObject projectile = Instantiate(weaponObject, transform.position, Quaternion.identity);
                projectile.GetComponent<Weapon>().Preapare(transform, nearestEnemy.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);
                break;
            case 2:
                //Vector3 newPositionC = new Vector3(transform.position.x, transform.position.y, 0);

                GameObject projectileC = Instantiate(weaponObject, transform.position, Quaternion.identity);
                projectileC.GetComponent<Weapon>().Preapare(transform, nearestEnemy.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);
                break;
            default:
                break;
        }
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
