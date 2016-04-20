using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScenario : MonoBehaviour {

    string timesAnswered;
    string timesCorrect;
    Text currentText;

    // Use this for initialization
    void Start () {
        currentText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        timesAnswered = Data.timesAnswered.ToString();
        timesCorrect = Data.timesCorrect.ToString();

        currentText.text = "You answered " + timesAnswered + " times in order to get " + timesCorrect + " correct answers. \n\n SHOW STARS HERE OR SUMFIN...";
    }
}
