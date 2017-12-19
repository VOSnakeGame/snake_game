using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour {

	public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {	
		gameOverScreen.SetActive(false);	
	}

	public void OnGameOver() {
		gameOverScreen.SetActive(true);		
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame() {
		SceneManager.LoadScene("Lvls", LoadSceneMode.Single);
	}

}
