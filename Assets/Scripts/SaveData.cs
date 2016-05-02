﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveData : MonoBehaviour {

    string previousScene;
    bool save;

    void Start()
    {
        previousScene = PlayerPrefs.GetString("PrevScene");

        //if (previousScene == "Scenario 1")
        //{
        //    SaveDataScenario1();
        //}

        //if(previousScene == "Scenario 2")
        //{
        //    SaveDataScenario2();
        //}

        if(previousScene == "Scenario 1" || previousScene == "Scenario 2")
        {
            SaveAllData();
        }
    }


    public void SaveDataScenario1()
    {
        int lastScenario = Data.scenario_1.Count - 1;
        //filename = count.ToString();
        //string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + "_Scenario1.txt";
        string path = @"c:\P6Data\" + Data.ParticipantsName + "_Scenario1.txt";
        if (!File.Exists(path))
        {
            string[] createText = new String[1];



            createText[lastScenario] =
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Total time: " + Data.TotalTime.ToString() + Environment.NewLine;
                ;

            File.WriteAllLines(path, createText);
        }
        else
        {
            string appendText =
                Environment.NewLine + 
                "Attempt: " + (lastScenario+1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Total time: " + Data.TotalTime.ToString() + Environment.NewLine
            ;
            File.AppendAllText(path, appendText);
        }
    }

    void SaveDataScenario2()
    {
        int lastScenario = Data.scenario_2.Count - 1;

        //string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + "_Scenario2.txt";
        string path = @"c:\P6Data\" + Data.ParticipantsName + "_Scenario2.txt";
        if (!File.Exists(path))
        {
            string[] createText = new String[1];

            createText[lastScenario] =
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine
                ;

            File.WriteAllLines(path, createText);
        }
        else
        {
            string appendText =
                Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine
                ;
            File.AppendAllText(path, appendText);
        }
    }

    void SaveAllData()
    {
        int lastScenario;
        int scenario;
        string previousScene = PlayerPrefs.GetString("PrevScene");

        if (previousScene == "Scenario 1")
        {
            lastScenario = Data.scenario_1.Count - 1;
            scenario = 1;
        }
        else
        {
            lastScenario = Data.scenario_2.Count - 1;
            scenario = 2;
        }
        //filename = count.ToString();
        //string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + "_Scenario1.txt";
        string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (!File.Exists(path))
        {
            string[] createText = new String[1];



            createText[lastScenario] =
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_1[lastScenario].Stars.ToString() + Environment.NewLine;

            File.WriteAllLines(path, createText);
        }
        else
        {
            string appendText =
                Environment.NewLine +
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_1[lastScenario].Stars.ToString() + Environment.NewLine;

            File.AppendAllText(path, appendText);
        }
    }
}
