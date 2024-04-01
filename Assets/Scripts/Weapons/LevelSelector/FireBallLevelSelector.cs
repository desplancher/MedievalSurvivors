using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public interface IWeaponLevelSelector
{
    void SelectLevel(GameObject weaponObject, UnityEngine.Transform weaponManagerTransform, GameObject nearestEnemy, int level, float lifeTimeMax, int damage, float range, float scale, float speed);



}

public class FireBallLevelSelector : IWeaponLevelSelector
{

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SelectLevel(GameObject weaponObject, UnityEngine.Transform weaponManagerTransform, GameObject nearestEnemy,int level, float lifeTimeMax, int damage, float range, float scale, float speed)
    {
        switch (level)
        {
            case 1:
                LevelOne(weaponObject, weaponManagerTransform, nearestEnemy, lifeTimeMax, damage, range, scale, speed);

                break;
            /*case 2:
                LevelTwo(lvl, extraDamage, origem, projetil);
                break;
            case 3:
                LevelTree(lvl, extraDamage, origem, projetil);
                break;
            case 4:
                LevelFour(lvl, extraDamage, origem, projetil);
                break;
            case 5:
                LevelFive(lvl, extraDamage, origem, projetil);
                break;
            */

            default:
                break;
        }


    }

    private void LevelOne(GameObject weaponObject, UnityEngine.Transform weaponManagerTransform,
                          GameObject nearestEnemy, float lifeTimeMax, int damage, float rangeConjurations, float sizeProjects, float speed  )
    {
        GameObject projectile = UnityEngine.Transform.Instantiate(weaponObject, weaponManagerTransform.position, Quaternion.identity);
        projectile.GetComponent<Weapon>().Preapare(weaponManagerTransform, nearestEnemy.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);
    }


   // GameObject projectile = Instantiate(weaponObject, transform.position, Quaternion.identity);
   // projectile.GetComponent<Weapon>().Preapare(transform, nearestEnemy.transform, lifeTimeMax, damage, rangeConjurations, sizeProjects, speed);

    /*
        private void LevelTwo(int lvl, float extraDamage, Vector3 origem, GameObject projetil)
        {
            Weapon arma = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma.lvlWeapon = lvl;
            arma.power = extraDamage;

            Weapon arma1 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma1.lvlWeapon = lvl - 1;
            arma1.power = extraDamage;
            arma1.transform.Rotate(0, 0, 180);

        }


        private void LevelTree(int lvl, float extraDamage, Vector3 origem, GameObject projetil)
        {
            Weapon arma1 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma1.lvlWeapon = lvl - 1;
            arma1.power = extraDamage;
            arma1.transform.Rotate(0, 0, 0);

            Weapon arma2 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma2.lvlWeapon = lvl - 1;
            arma2.power = extraDamage;
            arma2.transform.Rotate(0, 0, 120);

            Weapon arma3 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma3.lvlWeapon = lvl;
            arma3.power = extraDamage;
            arma3.transform.Rotate(0, 0, 240);

        }

        private void LevelFour(int lvl, float extraDamage, Vector3 origem, GameObject projetil)
        {
            Weapon arma = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma.lvlWeapon = lvl;
            arma.power = extraDamage;

            Weapon arma1 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma1.lvlWeapon = lvl - 1;
            arma1.power = extraDamage;
            arma1.transform.Rotate(0, 0, 90);

            Weapon arma2 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma2.lvlWeapon = lvl - 1;
            arma2.power = extraDamage;
            arma2.transform.Rotate(0, 0, -90);

            Weapon arma3 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma3.lvlWeapon = lvl;
            arma3.power = extraDamage;
            arma3.transform.Rotate(0, 0, 180);

        }

        private void LevelFive(int lvl, float extraDamage, Vector3 origem, GameObject projetil)
        {
            MeuLvlQuatro(lvl, extraDamage, origem, projetil);

            Weapon arma = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma.lvlWeapon = lvl;
            arma.power = extraDamage;
            arma.transform.Rotate(0, 0, 45);

            Weapon arma1 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma1.lvlWeapon = lvl - 1;
            arma1.power = extraDamage;
            arma1.transform.Rotate(0, 0, 135);

            Weapon arma2 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma2.lvlWeapon = lvl - 1;
            arma2.power = extraDamage;
            arma2.transform.Rotate(0, 0, -45);

            Weapon arma3 = Transform.Instantiate(projetil, origem, Quaternion.identity).GetComponent<Weapon>();
            arma3.lvlWeapon = lvl;
            arma3.power = extraDamage;
            arma3.transform.Rotate(0, 0, -135);

        }


    */




}
