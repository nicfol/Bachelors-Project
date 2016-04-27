using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveData : MonoBehaviour {

    // Used to represent test participant number - this is just temporary.
    public int count = 1;
	
    ///<summary>
    /// Call to save all data. All data is saved in ONE file called Data.txt, while one file per participant is also saved seperately.    
    ///</summary>
    public void SaveAllData()
    {
        SaveDataToOneFile();
        SaveOneFilePerParticipant(count);
    }

	// Used to save all data in one single file
    private void SaveDataToOneFile()
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


    // Used to save single files
    private void SaveOneFilePerParticipant(int filename)
    {
        //filename = count.ToString();
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + count.ToString() + ".txt";

        if (!File.Exists(path))
        {
            string[] createText = { Data.correctAnswers.Count.ToString() + "," + Data.wrongAnswers.Count.ToString() + "," + Data.timesAnswered.ToString() };
            File.WriteAllLines(path, createText);
        }
    }
}

