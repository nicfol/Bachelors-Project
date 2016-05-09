using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Quit : MonoBehaviour {
    int buttonCount = 0;
    float buttonCooler = 0.5f;
    bool hasTapped = false;
    public GameObject confirmationBox;

    float lastClickTime;
    float catchTime = 0.25f;

    // Use this for initialization
    void Start () {
        
	
	}

    // Update is called once per frame
    void Update() {
        if (hasTapped)
        {
            if (Time.time - lastClickTime < catchTime)
            {
                //double click
                confirmationBox.GetComponent<ShowHide>().showhideGO();
                if (!Data.TimeAndProgressSaved)
                {
                    SaveTimeAndProgess();
                    Data.TimeAndProgressSaved = true;
                }
                
            }
            else {
                //normal click
                
            }
            lastClickTime = Time.time;
            hasTapped = false;
        }
        
    }

    public void Tap()
    {
        hasTapped = true;
    }

    public void QuitApplication()
    {
        Application.Quit();
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
            string scenes = string.Join(", ", Data.Scenes.ToArray());
            createText[0] = Environment.NewLine + "Total time: " + Data.TotalTime.ToString() + Environment.NewLine + "Progress: " + Mathf.CeilToInt(Data.Progression).ToString() + Environment.NewLine + "Scenes visited: " + scenes;

            File.WriteAllLines(path, createText);
        }
        else
        {
            string scenes = string.Join(", ", Data.Scenes.ToArray());
            string appendText = Environment.NewLine + "Total time: " + Data.TotalTime.ToString() + Environment.NewLine + "Progress: " + Mathf.CeilToInt(Data.Progression).ToString() + Environment.NewLine + "Scenes visited: " + scenes;

            File.AppendAllText(path, appendText);
        }

    }
}
