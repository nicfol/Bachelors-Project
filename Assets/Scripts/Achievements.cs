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

        ach_1 = new Achievement { Name = "To the rescue!", isUnlocked = false, levelToUnlock = 1 };
        ach_2 = new Achievement { Name = "Save an adult", isUnlocked = false, levelToUnlock = 1 };
        ach_3 = new Achievement { Name = "Save an infant", isUnlocked = false, levelToUnlock = 1 };
        ach_4 = new Achievement { Name = "You are just like a medic!", isUnlocked = false, levelToUnlock = 1 };
        ach_5 = new Achievement { Name = "Achievement #5", isUnlocked = false, levelToUnlock = 1 };

        achievementList.Add(new Achievement { Name = "To the rescue!", isUnlocked = false, levelToUnlock = 1 });

    }

    // Update is called once per frame
    void Update() {
        
	}
}

public class Achievement
{
    public string Name { get; set; }
    public bool isUnlocked { get; set; }
    public int levelToUnlock { get; set; }
}

