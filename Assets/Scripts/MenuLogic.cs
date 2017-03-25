using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
	public AudioManager audioManager;
	// Update is called once per frame

	public void StartGame()
	{
		//audioManager.StopMusic();
		SceneManager.LoadScene("Game");
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
