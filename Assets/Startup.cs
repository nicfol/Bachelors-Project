using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

    // Use this for initialization
    void Start () {

        // Move this to AchievementHandler after meeting
        Data.InitializeAchievements();
    }
}
