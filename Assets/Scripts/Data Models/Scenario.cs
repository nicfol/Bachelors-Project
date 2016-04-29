using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scenario {

    //public int timesAnswered { get; set; }
    //public int timesCorrect { get; set; }
    //public int timesPressed { get; set; }
    public int wrongAnswers { get; set; }
    public int correctAnswers { get; set; }
    public int totalAnswers { get; set; }

    [HideInInspector]
    public List<string> wrongAnswersList = new List<string>();

    public int Stars { get; set; }
}
