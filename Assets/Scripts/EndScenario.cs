using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScenario : MonoBehaviour {

    public int numberOfQuestions = 14;
    public int threeStarsMin = 12;
    public int twoStarsMin = 9;
    public int oneStarMin = 7;

    public Text currentText;

    public bool scenario_1;
    public bool scenario_2;

    private Scenario scenario;

    // Use this for initialization
    void Start () {

        if (scenario_1)
        {
            scenario = Data.scenario_1;
        }
        else if (scenario_2)
        {
            scenario = Data.scenario_2;
        }
        else
        {
            Debug.Log("Stars script: You forgot to set the ID of the scenario.");
        }


        if (currentText == null)
        {
            currentText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {


        currentText.text = "You used "+ scenario.timesAnswered.ToString() + " attempts.\nYou got " + scenario.timesCorrect.ToString() + " correct answers.\n You got " + scenario.wrongAnswers.Count.ToString() + " wrong answers.";

        if (scenario.timesCorrect >= threeStarsMin)
        {
            // Show 3 stars
            scenario.Stars = 3;

        }
        else if (scenario.timesCorrect >= twoStarsMin)
        {
            // Show 2 stars
            scenario.Stars = 2;

        }
        else if(scenario.timesCorrect >= oneStarMin)
        {
            // Show 1 star  
            scenario.Stars = 1;
        }
        else
        {
            scenario.Stars = 0;
        }

        
    }
}
