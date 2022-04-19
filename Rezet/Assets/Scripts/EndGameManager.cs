using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    //public static GameObject endGameMenu;


    // Start is called before the first frame update
    void Start()
    {
        //endGameMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retryGame()
	{
        Debug.Log("Returning to game...");
        //endGameMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene("Level001");

    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();

    }
}
