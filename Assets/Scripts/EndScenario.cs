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


    }
	
	// Update is called once per frame
	void Update () {


        currentText.text = "Du har brugt "+ scenario.totalAnswers.ToString() + " Forsøg.\nDu fik " + scenario.correctAnswers.ToString() + " svar rigtigt.\n Du havde " + scenario.wrongAnswers.ToString() + " forkerte svar.";
        if(player.scenarioNumber == 1)
        {
            if (scenario.totalAnswers <= 14)
            {
                // Show 3 stars
                scenario.Stars = 3;

            }
            else if (scenario.totalAnswers <= 18)
            {
                // Show 2 stars
                scenario.Stars = 2;

            }
            else if (scenario.totalAnswers <= 24)
            {
                // Show 1 star  
                scenario.Stars = 1;
            }
            else
            {
                scenario.Stars = 0;
            }
        }
        else if(player.scenarioNumber == 2)
        {
            if (scenario.totalAnswers <= 10)
            {
                // Show 3 stars
                scenario.Stars = 3;

            }
            else if (scenario.totalAnswers <= 14)
            {
                // Show 2 stars
                scenario.Stars = 2;

            }
            else if (scenario.totalAnswers <= 19)
            {
                // Show 1 star  
                scenario.Stars = 1;
            }
            else
            {
                scenario.Stars = 0;
            }
        }

        // Add progression to depending on stars earned in Scenario 1
        if (Data.ScenarioWithMostStars(1).Stars > 0)
        {
            if (Data.ScenarioWithMostStars(1).Stars >= 1 && !Data.scenario1ProgStars[0])
            {
                Data.Progression += 9.633333f;
                Data.scenario1ProgStars[0] = true;
            }

            if (Data.ScenarioWithMostStars(1).Stars >= 2 && !Data.scenario1ProgStars[1])
            {
                Data.Progression += 9.633333f;
                Data.scenario1ProgStars[1] = true;
            }

            if (Data.ScenarioWithMostStars(1).Stars >= 3 && !Data.scenario1ProgStars[2])
            {
                Data.Progression += 9.633333f;
                Data.scenario1ProgStars[2] = true;
            }
        }

        // Add progression to depending on stars earned in Scenario 2
        if (Data.ScenarioWithMostStars(2).Stars > 0)
        {
            if (Data.ScenarioWithMostStars(2).Stars >= 1 && !Data.scenario2ProgStars[0])
            {
                Data.Progression += 9.633333f;
                Data.scenario2ProgStars[0] = true;
            }

            if (Data.ScenarioWithMostStars(2).Stars >= 2 && !Data.scenario2ProgStars[1])
            {
                Data.Progression += 9.633333f;
                Data.scenario2ProgStars[1] = true;
            }

            if (Data.ScenarioWithMostStars(2).Stars >= 3 && !Data.scenario2ProgStars[2])
            {
                Data.Progression += 9.633333f;
                Data.scenario2ProgStars[2] = true;
            }
        }

    }
}
