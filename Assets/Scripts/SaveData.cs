﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveData : MonoBehaviour {

    string previousScene;
    bool save;
    int scenario;
    int lastScenario;

    void Start()
    {
        previousScene = PlayerPrefs.GetString("PrevScene");

        //if(previousScene == "Scenario 1" || previousScene == "Scenario 2")
        //{
        //    SaveAllData();
        //}

        if(previousScene == "Scenario 1")
        {
            SaveScenario1Data();
            Debug.Log("Scenario 1 save data ran");
        }

        if (previousScene == "Scenario 2")
        {
            SaveScenario2Data();
            Debug.Log("Scenario 2 save data ran");
        }
    }

    void SaveScenario1Data()
    {
        Debug.Log("Processing data recieved from scenario : " + previousScene);

        lastScenario = Data.scenario_1.Count - 1;
        scenario = 1;

        Debug.Log("SaveAllData method is now running !");
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        //string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (!File.Exists(path))
        {
            string[] createText = {
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_1[lastScenario].Stars.ToString() + Environment.NewLine };
        try { 
            File.WriteAllLines(path, createText);
        } catch (Exception e)
        {
            Debug.Log(e);
        }
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
            try { 
            File.AppendAllText(path, appendText);
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }            
    }

    void SaveScenario2Data()
    {
        Debug.Log("Processing data recieved from scenario : " + previousScene);

        lastScenario = Data.scenario_2.Count - 1;
        scenario = 2;

        Debug.Log("SaveAllData method is now running !");
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        //string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (!File.Exists(path))
        {
            string[] createText = {
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_2[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_2[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_2[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_2[lastScenario].Stars.ToString() + Environment.NewLine };
        try { 
            File.WriteAllLines(path, createText);
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }
        else
        {
            string appendText =
                Environment.NewLine +
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_2[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_2[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_2[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_2[lastScenario].Stars.ToString() + Environment.NewLine;
        try {
            File.AppendAllText(path, appendText);
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    }



    void SaveAllData()
    {
        Debug.Log("Processing data recieved from scenario : " + previousScene);

        if (previousScene == "Scenario 1")
        {
            lastScenario = Data.scenario_1.Count - 1;
            scenario = 1;
        }
        if(previousScene == "Scenario 2")
        {
            lastScenario = Data.scenario_2.Count - 1;
            scenario = 2;
        }

        Debug.Log("SaveAllData method is now running !");
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + Data.ParticipantsName + ".txt";
        //string path = @"c:\P6Data\" + Data.ParticipantsName + ".txt";
        if (!File.Exists(path))
        {
            string[] createText = new String[1];

            Debug.Log("Files does not exist. Trying to create file...");
            if(scenario == 1)
            {
                Debug.Log("Saving data for Scenario 1...");
                createText[lastScenario] =
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_1[lastScenario].Stars.ToString() + Environment.NewLine;
                Debug.Log("Data saved !");
            }

            if (scenario == 2)
            {
                Debug.Log("Saving data for Scenario 2...");
                createText[lastScenario] =
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_2[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_2[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_2[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_2[lastScenario].Stars.ToString() + Environment.NewLine;
                Debug.Log("Data saved !");
            }

            Debug.Log("##################################################################_-----------_#_#_#_#_#__#_#__#_#");
            Debug.Log(scenario);
            Debug.Log(previousScene);
            Debug.Log(createText[lastScenario]);

            try { 
            File.WriteAllLines(path, createText);
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }
        else
        {
            Debug.Log("Appending data for Scenario 1...");
            string appendText = "";
            if(scenario == 1)
            {
                appendText =
                Environment.NewLine +
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_1[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_1[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_1[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_1[lastScenario].Stars.ToString() + Environment.NewLine;
                Debug.Log("Data saved !");
            }

            if (scenario == 2)
            {
                Debug.Log("Appending data for Scenario 2...");
                appendText =
                Environment.NewLine +
                "Scenario: " + scenario.ToString() + Environment.NewLine +
                "Attempt: " + (lastScenario + 1).ToString() + Environment.NewLine +
                "Total answers: " + Data.scenario_2[lastScenario].totalAnswers.ToString() + Environment.NewLine +
                "Correct answers: " + Data.scenario_2[lastScenario].correctAnswers.ToString() + Environment.NewLine +
                "Wrong answers: " + Data.scenario_2[lastScenario].wrongAnswers.ToString() + Environment.NewLine +
                "Stars: " + Data.scenario_2[lastScenario].Stars.ToString() + Environment.NewLine;
                Debug.Log("Data saved !");
            }

            try {
                File.AppendAllText(path, appendText);
            } catch (Exception e)
            {
                Debug.Log(e);
            }
            Debug.Log("##################################################################_-----------_#_#_#_#_#__#_#__#_#");
            Debug.Log(scenario);
            Debug.Log(previousScene);
            Debug.Log(appendText);
        }
    }
}

