using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Quit : MonoBehaviour {
    int buttonCount = 0;
    float buttonCooler = 0.5f;
    bool hasTapped = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Tap())
        {

            if (buttonCooler > 0 && buttonCount == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped
                Debug.Log("Double tap");
            }
            else {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }

            hasTapped = false;
        }

        if (buttonCooler > 0)
        {

            buttonCooler -= 1 * Time.deltaTime;

        }
        else {
            buttonCount = 0;
        }

    }

    public bool Tap()
    {
        hasTapped = true;
        buttonCount++;
        return hasTapped;
    }

    public void SaveTimeAndProgess()
    {
        Data.TotalTime = Time.time - Data.InitialSceneTime;

        Debug.Log("Total time: " + Data.TotalTime);

        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        //string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (!File.Exists(path))
        {
            string[] createText = new String[1];

            createText[0] = Environment.NewLine + "Total time: " + Data.TotalTime.ToString() + Environment.NewLine + "Progress: " + Mathf.CeilToInt(Data.Progression).ToString();

            File.WriteAllLines(path, createText);
        }
        else
        {
            string appendText = Environment.NewLine + "Total time: " + Data.TotalTime.ToString() + Environment.NewLine + "Progress: " + Mathf.CeilToInt(Data.Progression).ToString();
            File.AppendAllText(path, appendText);
        }

    }
}
