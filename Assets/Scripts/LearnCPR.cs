using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LearnCPR : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!Data.ach6.isUnlocked)
        {
            if (SceneManager.GetActiveScene().name == "BasicCPR")
            {
                Data.LearnCPRVisited[0] = true;
            }

            if (SceneManager.GetActiveScene().name == "RecoveryPos")
            {
                Data.LearnCPRVisited[1] = true;
            }

            if (SceneManager.GetActiveScene().name == "AED")
            {
                Data.LearnCPRVisited[2] = true;
            }
        }

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
