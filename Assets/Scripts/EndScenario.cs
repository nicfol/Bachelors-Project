using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScenario : MonoBehaviour {
    public int numberOfQuestions = 14;
    public int threeStarsMin = 12;
    public int twoStarsMin = 9;
    public int oneStarMin = 7;
    string timesAnswered;
    string timesCorrect;
    string timesWrong;
    public Text currentText;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    // Use this for initialization
    void Start () {

        
        if(currentText == null)
        {
            currentText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if(star1 == null)
        {
            star1 = GameObject.Find("Star1");
        }
        if (star2 == null)
        {
            star2 = GameObject.Find("Star2");
        }
        if (star3 == null)
        {
            star3 = GameObject.Find("Star3");
        }

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        timesAnswered = Data.timesAnswered.ToString();
        timesCorrect = Data.timesCorrect.ToString();
        timesWrong = Data.wrongAnswers.Count.ToString();

        currentText.text = "You used "+ timesAnswered + " attempts.\nYou got " + timesCorrect + " correct answers.\n You got " + timesWrong + " wrong answers.";

        if (Data.timesAnswered >= threeStarsMin)
        {
            // Show 3 stars
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (Data.timesAnswered >= twoStarsMin)
        {
            // Show 2 stars
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if(Data.timesAnswered >= oneStarMin)
        {
            // Show 1 star  
            Debug.Log("Star 1 is active!");
            star1.SetActive(true);         
        }
        else
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        
    }
}
