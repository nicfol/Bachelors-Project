﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAchievements : MonoBehaviour
{

    int achievementGap1;
    int achievementGap2;

    Text achievementText;
    GameObject checkmark;

    bool showAchievements;
    
    public Sprite newBackground;

    Vector2 pos;
    // Use this for initialization
    void Start()
    {
        achievementGap1 = 0;
        achievementGap2 = 0;


        for (int i = 0; i < Data.achievements.Count; i++)
        {
            GameObject ach = Instantiate(Resources.Load("Achievement")) as GameObject;
            ach.transform.SetParent(gameObject.transform);
            if(i <= 5)
            {
                pos = new Vector2(-210, 125 - achievementGap1);
                achievementGap1 += 65;
            }
            else
            {
                pos = new Vector2(210, 125 - achievementGap2);
                achievementGap2 += 65;
            }
            
            ach.GetComponent<RectTransform>().anchoredPosition = pos;

            achievementText = ach.transform.GetChild(1).GetComponent<Text>();
            achievementText.text = Data.achievements[i].Name;

            checkmark = ach.transform.GetChild(2).gameObject;
            checkmark.SetActive(false);

            if (Data.achievements[i].isUnlocked)
            {
                GameObject backdrop = ach.gameObject.transform.GetChild(0).gameObject;
                backdrop.GetComponent<Image>().sprite = newBackground;
                checkmark.SetActive(true);
            }
        }

    }
}
