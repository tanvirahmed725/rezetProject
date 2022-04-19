using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;

    public string firstLevel;

    public void PlayGame()
    {
        mainMenuCanvas.SetActive(false);
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
