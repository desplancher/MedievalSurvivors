using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallLevelSelector : MonoBehaviour
{
    public GameObject weaponManagerObject;
    private WeaponManager weaponManager;
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = weaponManagerObject.GetComponent<WeaponManager>();
        SelectLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SelectLevel()
    {
        switch (weaponManager.level)
        {
            case 1:
                break;
            case 2:
                weaponManager.damage += 10;
                break;
            case 3:
                weaponManager.speed += 10;
                break;
            default:
                break;
        }
    }







}
