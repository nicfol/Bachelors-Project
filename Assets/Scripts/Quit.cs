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

    public void SaveTotalTime()
    {
        Data.TotalTime = Time.time - Data.InitialSceneTime;

        Debug.Log("Total time: " + Data.TotalTime);

        //string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (File.Exists(path))
        {
            string appendText = Environment.NewLine + "Total time: " + Data.TotalTime.ToString();
            File.AppendAllText(path, appendText);
        }

    }
}
