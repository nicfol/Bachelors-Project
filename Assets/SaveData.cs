using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveData : MonoBehaviour {

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
            //string[] createText = { count + "," + Data.scenario_1.correctAnswers.Count.ToString() + "," + Data.scenario_1.wrongAnswers.Count.ToString() + "," + Data.scenario_1.timesAnswered.ToString() };
            //File.WriteAllLines(path, createText);
        }
        else
        {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            //count++;
            //string appendText = count + "," + Data.scenario_1.correctAnswers.Count.ToString() + "," + Data.scenario_1.wrongAnswers.Count.ToString() + "," + Data.scenario_1.timesAnswered.ToString() + Environment.NewLine;
            //File.AppendAllText(path, appendText);
        }
    }


    // Used to save single files
    private void SaveParticipantData ()
    {
        //filename = count.ToString();
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";

        if (!File.Exists(path))
        {
            string[] createText;
            string text;
            for (int i = 0; i < Data.scenario_1.Count; i++)
            {
                
                text = 
                    "Participant: " + Data.ParticipantsName + Environment.NewLine +
                    "Total answers: " + Data.scenario_1[i].totalAnswers.ToString() + Environment.NewLine +
                    "Correct answers: " + Data.scenario_1[i].correctAnswers.ToString() + Environment.NewLine +
                    "Wrong answers: " + Data.scenario_1[i].wrongAnswers.ToString() + Environment.NewLine
                    ;
                createText[i] = text;
            }
            
            File.WriteAllLines(path, createText);
        }
    }
}

