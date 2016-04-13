using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static int timesAnswered { get; internal set; }
    public static int timesCorrect { get; internal set; }
    public static int timesPressed { get; internal set; }


    public static List<string> wrongAnswers = new List<string>();
    public static List<string> correctAnswers = new List<string>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
