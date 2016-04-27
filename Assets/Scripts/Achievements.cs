using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Achievements : MonoBehaviour {

    public Achievement ach_1;
    public Achievement ach_2;
    public Achievement ach_3;
    public Achievement ach_4;
    public Achievement ach_5;

    public List<Achievement> achievementList = new List<Achievement>();

    // Use this for initialization
    void Start () {

        ach_1 = new Achievement { Name = "Du har gennemført et scenarie !", isUnlocked = false };
        ach_2 = new Achievement { Name = "Nysgerrig", isUnlocked = false };
        ach_3 = new Achievement { Name = "Save an infant", isUnlocked = false };
        ach_4 = new Achievement { Name = "You are just like a medic!", isUnlocked = false };
        ach_5 = new Achievement { Name = "Achievement #5", isUnlocked = false };
        achievementList.Add(ach_1);
        achievementList.Add(ach_2);
        achievementList.Add(ach_3);
        achievementList.Add(ach_4);
        achievementList.Add(ach_5);
    }

    // Update is called once per frame
    void Update() {
        //foreach(var a in achievementList)
        //{
        //    if(a.levelToUnlock = )
        //}
	}
}

public class Achievement
{
    public string Name { get; set; }
    public bool isUnlocked { get; set; }
}

