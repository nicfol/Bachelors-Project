using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static string ParticipantsName { get; set; }
    public static float InitialSceneTime { get; set; }
    public static float TotalTime { get; set; }

    public static List<Scenario> scenario_1 = new List<Scenario>();
    public static List<Scenario> scenario_2 = new List<Scenario>();

    public static List<Achievement> achievements = new List<Achievement>();

    public static Achievement ach1;
    public static Achievement ach2;
    public static Achievement ach3;
    public static Achievement ach4;
    public static Achievement ach5;

    public static void InitializeAchievements()
    {
        achievements.Add(new Achievement { Name = "Du har gennemført et scenarie !", isUnlocked = false });
        achievements.Add(new Achievement { Name = "Nysgerrig", isUnlocked = false });
        achievements.Add(new Achievement { Name = "Replace this name plz.", isUnlocked = false });
        achievements.Add(new Achievement { Name = "You are just like a medic!", isUnlocked = false });
        achievements.Add(new Achievement { Name = "Achievement #5", isUnlocked = false });

        ach1 = achievements[0];
        ach2 = achievements[1];
        ach3 = achievements[2];
        ach4 = achievements[3];
        ach5 = achievements[4];
    }

    public static Scenario ScenarioWithMostStars(int scenarioNumber)
    {
        Scenario s = new Scenario();
        int tempStars = 0;

        if (scenarioNumber == 1)
        {
            for (int i = 0; i < scenario_1.Count; i++)
            {
                if (scenario_1[i].Stars > tempStars)
                {
                    s = scenario_1[i];
                }
            }
        }

        if(scenarioNumber == 2)
        {
            for (int i = 0; i < scenario_2.Count; i++)
            {
                if (scenario_2[i].Stars > tempStars)
                {
                    s = scenario_2[i];
                }
            }
        }

        return s;
    }
}
