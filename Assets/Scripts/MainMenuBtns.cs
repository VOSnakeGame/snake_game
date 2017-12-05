using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour {

    public Button playBtn;
    public Button quitBtn;

    // Use this for initialization
    void Start () {
        Button playBtnClick = playBtn.GetComponent<Button>();
        Button quitBtnClick = playBtn.GetComponent<Button>();
        playBtnClick.onClick.AddListener(OpenLvlsListener);
        quitBtnClick.onClick.AddListener(QuitGameListener);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OpenLvlsListener()
    {
        SceneManager.LoadScene("Lvls", LoadSceneMode.Single);
    }

    void QuitGameListener()
    {
        Application.Quit();
    }

}
