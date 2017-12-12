using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour {

	public GameObject gameOverScreen;
	public Button restartBtn;
	public Button quitBtn;	
	

	// Use this for initialization
	void Start () {	
		gameOverScreen.SetActive(false);	
        restartBtn.onClick.AddListener(RestartGame);
        quitBtn.onClick.AddListener(QuitGame);		
	}

	public void OnGameOver() {
		gameOverScreen.SetActive(true);		
	}

	void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void QuitGame() {
		SceneManager.LoadScene("Lvls", LoadSceneMode.Single);
	}

}
