using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestGetData : MonoBehaviour {

    private Text currentText;

	// Use this for initialization
	void Start () {
        currentText = gameObject.GetComponent<Text>();
        for (int i = 0; i < Data.scenario_1.Count; i++)
        {
            currentText.text += "\nAttempt: " + i+1.ToString() + " - Correct Answers: "  + Data.scenario_1[i].correctAnswers.ToString() + " - Wrong Answers: " + Data.scenario_1[i].wrongAnswers.ToString() + " - Stars: " + Data.scenario_1[i].Stars.ToString();
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
