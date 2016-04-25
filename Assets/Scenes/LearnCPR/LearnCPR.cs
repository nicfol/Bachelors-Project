using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LearnCPR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void BasicCPR()
    {
        SceneManager.LoadScene("BasicCPR");
    }

    public void AED()
    {
        SceneManager.LoadScene("AED");
    }

    public void RecoveryPos()
    {
        SceneManager.LoadScene("RecoveryPos");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToLearnCPR()
    {
        SceneManager.LoadScene("LearnCPR");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
