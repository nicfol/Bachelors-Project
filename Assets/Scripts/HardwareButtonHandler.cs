using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HardwareButtonHandler : MonoBehaviour {

    private string previousScene;
    private string currentScene;
    
	// Use this for initialization
	void Start () {
        previousScene = PlayerPrefs.GetString("CurrentScene"); 
	    PlayerPrefs.SetString("PrevScene", previousScene);
        
        currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log(currentScene);
        PlayerPrefs.SetString("CurrentScene", currentScene);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Back button pressed, returns to " + previousScene);
            SceneManager.LoadScene(previousScene);
        }
	}
}
