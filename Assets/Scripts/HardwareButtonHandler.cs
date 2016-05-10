using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HardwareButtonHandler : MonoBehaviour {

    private string previousScene;
    private string currentScene;
    
	// Use this for initialization
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        previousScene = PlayerPrefs.GetString("CurrentScene"); 
	    PlayerPrefs.SetString("PrevScene", previousScene);
        
        currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log(currentScene);
        PlayerPrefs.SetString("CurrentScene", currentScene);
	}
	
	// Update is called once per frame
	void Update () {
        if(currentScene != "Scenario 1" && currentScene != "Scenario 2" && previousScene != "Scenario 1" && previousScene != "Scenario 2") {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Debug.Log("Back button pressed, returns to " + previousScene);
                SceneManager.LoadScene(previousScene);
            }
        }
	}
}
