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
    public float cooldownTime;
    public float actualCooldown;
    public float lifeTimeMax;
    public float projectsRateMax;
    public float actualProjecstRate;

    public GameObject weaponObject;

    public WeaponStatus weaponStatus = WeaponStatus.Restarting;
    private void Start()
    {
        cooldownTime = 2;
    }
    void Update()
    {

        switch (weaponStatus)
        {
            case WeaponStatus.Cooldown:
                if(actualCooldown > 0)
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

    void WaitingNextFire()
    {
        actualProjecstRate -= Time.deltaTime;
        
        if (actualProjecstRate <= 0) 
        {
            weaponStatus = WeaponStatus.Firing;
        }
    }

    void Firing()
    {
        switch (level)
        {
            case 0:
                Debug.Log("Atira");
                break;
            case 1:
                Vector3 newPosition = new Vector3((float)(transform.position.x + 0.1), (float)(transform.position.y+0.1), 0);

                GameObject projectile = Instantiate(weaponObject, newPosition, Quaternion.identity);
                projectile.GetComponent<Weapon>().Preapare(transform, projectile.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);
                break;
            case 2:
                Vector3 newPositionC = new Vector3(transform.position.x, transform.position.y, 0);

                GameObject projectileC = Instantiate(weaponObject, newPositionC, Quaternion.identity);
                projectileC.GetComponent<Weapon>().Preapare(transform, projectileC.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);
                break;
            default:
                break;
        }
        actualProjects--;
        actualProjecstRate = projectsRateMax;

        weaponStatus = (actualProjects <= 0) ? WeaponStatus.Restarting : WeaponStatus.BetweenFire;
    }

    void RestartingWeapon() 
    {
        weaponStatus = WeaponStatus.Cooldown;
        actualCooldown = cooldownTime;
        actualProjecstRate = projectsRateMax;
        actualProjects = numberProjectsMax;
    }
}
