using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGroup : MonoBehaviour
{

    public List<int> listNumbers;

    public GameObject panelObject;
    public GameObject buttonBase;

    // Start is called before the first frame update
    void Start()
    {
        listNumbers = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPanelNormal()
    {
        panelObject.SetActive(true);
        Time.timeScale = 0;

        listNumbers.Clear();

        int WeaponsCount = Enum.GetNames(typeof(AllWeapons)).Length;

        var rand = new System.Random();

        do
        {
            int numbers = rand.Next(0, WeaponsCount);
            if (!listNumbers.Contains(numbers))
            {
                listNumbers.Add(numbers);
            }
        } while (listNumbers.Count < 4);
    }

    public void OpenPanelFullWeapons(WeaponManager[] WeaponsInPlayer)
    {
        panelObject.SetActive(true);
        Time.timeScale = 0;
        listNumbers.Clear();


        for (int i = 0; i < WeaponsInPlayer.Length; i++)
        {
            if (WeaponsInPlayer[i].level < WeaponsInPlayer[i].maxLevel)
            {
                listNumbers.Add((int)WeaponsInPlayer[i].nameWeapon);
            }
        }

        listNumbers.Sort();
    }

    public void ClosePanel()
    {
        panelObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void CreateButtons()
    {

    }
    public void ButtonClick()
    {

    }

    private void DoUpgrade()
    {

    }

    private void DoCreateWeaponManager()
    {

    }

    private void CreateButton()
    {
        GameObject newButton = Instantiate(buttonBase, panelObject.transform);
    }
}
