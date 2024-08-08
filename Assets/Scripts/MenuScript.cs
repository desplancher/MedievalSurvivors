using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectCharacter(string characterName)
    {
        MessengerClass.CharacterSelected = characterName;
        SceneManager.LoadScene("SelectMap");
    }

    public void SelectMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
