using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scenario {

    public int timesAnswered { get; internal set; }
    public int timesCorrect { get; internal set; }
    public int timesPressed { get; internal set; }

    [HideInInspector]
    public List<string> wrongAnswers = new List<string>();

    [HideInInspector]
    public List<string> correctAnswers = new List<string>();

    public int Stars { get; set; }

    public int NumberOfQuestions { get; set; }
}
