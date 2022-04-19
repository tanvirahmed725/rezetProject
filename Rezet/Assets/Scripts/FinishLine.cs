using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
	// Handle player colliding with finish line
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			Debug.Log("Player has hit the finish line.");
			//EndGameManager.endGameMenu.SetActive(true);

			SceneManager.LoadScene("End Game");

			// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
