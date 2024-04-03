using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

 public abstract class IWeaponLevelSelector : MonoBehaviour
{
    public float cooldownTime;
    public float projectsRateMax;
    public float lifeTimeMax;

    public abstract void SpawnWeapon(GameObject weaponObject, UnityEngine.Transform weaponManagerTransform, GameObject nearestEnemy, int level, float lifeTimeMax, int damage, float range, float scale, float speed);




}


public class FireBallLevelSelector : IWeaponLevelSelector
{
    public void Start()
    {
        LevelOne();
    }

    public override void SpawnWeapon(GameObject weaponObject, UnityEngine.Transform weaponManagerTransform, GameObject nearestEnemy,int level, float lifeTimeMax, int damage, float range, float scale, float speed)
    {
        SelectLevel(level);

        GameObject projectile = UnityEngine.Transform.Instantiate(weaponObject, weaponManagerTransform.position, Quaternion.identity);
        projectile.GetComponent<Weapon>().Preapare(weaponManagerTransform, nearestEnemy.transform, lifeTimeMax, damage, range, scale, speed);

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
        lifeTimeMax = 5;
    }

    private void LevelTwo()
    {
        cooldownTime = 2;
        projectsRateMax = 0.5f;
    }

    private void LevelTree()
    {
        cooldownTime = 1;
        projectsRateMax = 0.25f;
    }

    private void LevelFour()
    {
        cooldownTime = 0.5f;
        projectsRateMax = 0.15f;
    }

    private void LevelFive()
    {
        cooldownTime = 0.25f;
        projectsRateMax = 0.05f;
    }

}
