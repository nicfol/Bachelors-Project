using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScenario : MonoBehaviour {

    public Text currentText;

    private PlayerController player;
    private Scenario scenario;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Scenario Handler").GetComponent<PlayerController>();

        scenario = player.currentScenario;

        if (currentText == null)
        {
            currentText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (!Data.ach7.isUnlocked)
        {
            if (player.noWrongAnswer)
            {
                Data.ach7.isUnlocked = true;
                GameObject.Find("Achievement Manager").GetComponent<AchievementPopup>().DisplayPopup(Data.ach7.name);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {


        currentText.text = "You used "+ scenario.totalAnswers.ToString() + " attempts.\nYou got " + scenario.correctAnswers.ToString() + " correct answers.\n You got " + scenario.wrongAnswers.ToString() + " wrong answers.";

        if (scenario.correctAnswers >= player.threeStarsMin)
        {
            // Show 3 stars
            scenario.Stars = 3;

        }
        else if (scenario.correctAnswers >= player.twoStarsMin)
        {
            // Show 2 stars
            scenario.Stars = 2;

        }
        else if(scenario.correctAnswers >= player.oneStarMin)
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
