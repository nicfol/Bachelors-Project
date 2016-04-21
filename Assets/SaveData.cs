using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveData : MonoBehaviour {


    public int count = 1;
	
	// Update is called once per frame
    public void SaveDataToFile()
    {
        // For Android - path = Application.persistentDataPath + "/Data.txt";
        // For Windows - path = @"c:\P6Data\Data.txt";
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + "Data.txt"; 

        Debug.Log("Saved to " + path);

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            // Create a file to write to.
            string[] createText = { count + "," + Data.correctAnswers.Count.ToString() + "," + Data.wrongAnswers.Count.ToString() + "," + Data.timesAnswered.ToString() };
            File.WriteAllLines(path, createText);
        }
        else
        {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            count++;
            string appendText = count + "," + Data.correctAnswers.Count.ToString() + "," + Data.wrongAnswers.Count.ToString() + "," + Data.timesAnswered.ToString() + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }
    }
}

