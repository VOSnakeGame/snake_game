using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour {

    public Button clickedButton;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            string name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

            if (name.Contains("Nazad"))
            {
                BackScene();
            }
            else if (name.Contains("Nivo "))
            {
                SceneManager.LoadScene("Lvl" + name.Replace("Nivo ", ""), LoadSceneMode.Single);
            }
        }
        
    }
    
    void BackScene()
    {
        SceneManager.LoadScene("Mainmenu", LoadSceneMode.Single);
    }

}
