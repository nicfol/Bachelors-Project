using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static string ParticipantsName { get; set; }
    public static float InitialSceneTime { get; set; }
    public static float TotalTime { get; set; }
    public static float Progression { get; set; }
    public static List<string> Scenes = new List<string>();

    public static List<Scenario> scenario_1 = new List<Scenario>();
    public static List<Scenario> scenario_2 = new List<Scenario>();

    public static List<Achievement> achievements = new List<Achievement>();

    // Variables for achievements
    public static bool[] LearnCPRVisited = new bool[3];

    public static bool s1ProgStar1, s1ProgStar2, s1ProgStar3;
    public static bool s2ProgStar1, s2ProgStar2, s2ProgStar3;

    public static bool[] scenario1ProgStars;
    public static bool[] scenario2ProgStars;

    public static bool TimeAndProgressSaved { get; set; }

    public static Achievement ach1;
    public static Achievement ach2;
    public static Achievement ach3;
    public static Achievement ach4;
    public static Achievement ach5;
    public static Achievement ach6;
    public static Achievement ach7;
    public static Achievement ach8;
    public static Achievement ach9;

    public static void InitializeAchievements()
    {
        ach1 = new Achievement { Name = "Du har gennemført et scenarie!", isUnlocked = false };
        ach2 = new Achievement { Name = "Du har gennemført to scenarier!", isUnlocked = false };
        ach3 = new Achievement { Name = "Nysgerrig", isUnlocked = false };
        ach4 = new Achievement { Name = "50% - Som Bon Jovi sagde \"Whoa, we're half way there. \" ", isUnlocked = false };
        ach5 = new Achievement { Name = "100% - Det er sku imponerende!", isUnlocked = false };
        ach6 = new Achievement { Name = "Du burde overveje et job som livredder!", isUnlocked = false };
        ach7 = new Achievement { Name = "Du svarede ikke forkert en eneste gang!", isUnlocked = false };
        ach8 = new Achievement { Name = "3 rigtige i træk!", isUnlocked = false };
        ach9 = new Achievement { Name = "6 rigtige i træk!", isUnlocked = false };

        achievements.Add(ach1);
        achievements.Add(ach2);
        achievements.Add(ach3);
        achievements.Add(ach4);
        achievements.Add(ach5);
        achievements.Add(ach6);
        achievements.Add(ach7);
        achievements.Add(ach8);
        achievements.Add(ach9);

        scenario1ProgStars = new bool[3];
        scenario2ProgStars = new bool[3];
        for(int i= 0; i < 3; i++)
        {
            scenario1ProgStars[i] = false;
            scenario2ProgStars[i] = false;
        }
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
