using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGroup : MonoBehaviour
{

    public List<int> listNumbers;
    public List<string> namesWeaponsInPlayer;

    public Sprite TESTE;
    public GameObject panelObject;
    public GameObject buttonsLayout;
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

        CreateButtons();
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
               // listNumbers.Add((int)WeaponsInPlayer[i].nameWeapon);
            }
        }

        listNumbers.Sort();

        CreateButtons();
    }



    public void CreateButtons()
    {
        listWeaponsInPlayer();

        for (int i = 0;i < listNumbers.Count;i++)
        {
            CreateButton(listNumbers[i]);
        }


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

    private void CreateButton(int idWeapon)
    {
        GameObject newButton = Instantiate(buttonBase, buttonsLayout.transform);

        //newButton.transform.SetParent(buttonsLayout.transform);
        newButton.transform.localScale = Vector3.one;

        AllWeapons weaponSelected = (AllWeapons)idWeapon;

        Sprite spriteWeapon = Resources.Load<Sprite>("Images/Weapons/" + weaponSelected.ToString() + "_Tumbnail");

        

        Transform nameItem = newButton.transform.Find("Name");
        nameItem.GetComponent<TextMeshProUGUI>().text = weaponSelected.ToString();

        Transform spriteItem = newButton.transform.Find("Image");
        spriteItem.GetComponent<Image>().sprite = spriteWeapon;

        Transform attributesItem = newButton.transform.Find("Attributes");
        bool isNew = (namesWeaponsInPlayer.Contains(weaponSelected.ToString())) ? false : true;
        attributesItem.GetComponent<TextMeshProUGUI>().text = (isNew) ? "New" : "Old";


        newButton.GetComponent<Button>().onClick.AddListener(() => ChoiceUpgrade(weaponSelected.ToString(), isNew));


    }

    void ChoiceUpgrade(string name, bool isNew)
    {
        Debug.Log(name);

        if (isNew)
        {
            GameObject.Find("Player").GetComponent<Player>().CreateWeaponManager(name);
        } else
        {
            GameObject.Find(name + "Manager").GetComponent<WeaponManager>().UpgradeWeapon();
        }


        CloseUpgradePannel();

    }

    private void CloseUpgradePannel()
    {
        for (int i = buttonsLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(buttonsLayout.transform.GetChild(i).gameObject);
        }

        panelObject.SetActive(false);
        Time.timeScale = 1;
    }


    private void listWeaponsInPlayer()
    {
        namesWeaponsInPlayer.Clear();

        GameObject weaponsManagers = GameObject.Find("WeaponsManagers");

        
        
        for (int i = 0; i < weaponsManagers.transform.childCount; i++)
        {
            namesWeaponsInPlayer.Add(weaponsManagers.transform.GetChild(i).GetComponent<WeaponManager>().objectName);
           
        }
    }
}
