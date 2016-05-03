using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAchievements : MonoBehaviour
{

    int achievementGap;

    Text achievementText;
    GameObject checkmark;

    bool showAchievements;

    // Use this for initialization
    void Start()
    {
        achievementGap = 0;

        for (int i = 0; i < Data.achievements.Count; i++)
        {
            GameObject ach = Instantiate(Resources.Load("Achievement")) as GameObject;
            ach.transform.SetParent(gameObject.transform);
            Vector2 pos = new Vector2(1, 125 - achievementGap);
            ach.GetComponent<RectTransform>().anchoredPosition = pos;
            achievementGap += 52;

            achievementText = ach.transform.GetChild(1).GetComponent<Text>();
            achievementText.text = Data.achievements[i].Name;

            checkmark = ach.transform.GetChild(2).gameObject;
            checkmark.SetActive(false);

            if (Data.achievements[i].isUnlocked)
            {
                checkmark.SetActive(true);
            }
        }

    }
}
