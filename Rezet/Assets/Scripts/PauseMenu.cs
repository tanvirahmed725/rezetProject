using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
            if(GameIsPaused)
			{
                Resume();
			}
			else
			{
                Pause();
			}
		}
    }

    public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		GameIsPaused = false;
		AudioListener.volume = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

	public void Pause()
	{
		AudioListener.volume = 0f;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void QuitGame()
	{
		Debug.Log("Quiting Game...");
		Application.Quit();

	}

}
