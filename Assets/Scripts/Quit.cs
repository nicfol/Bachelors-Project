using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveTimeAndProgess()
    {
        Data.TotalTime = Time.time - Data.InitialSceneTime;

        Debug.Log("Total time: " + Data.TotalTime);

        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        //string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (File.Exists(path))
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
