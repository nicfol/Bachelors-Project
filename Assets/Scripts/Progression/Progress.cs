using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    Image foregroundImage;
    public Text percentage;

    float value
    {
        get
        {
            if (foregroundImage != null)
                return (float)(foregroundImage.fillAmount * 100);
            else
                return 0f;
        }

        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value / 100f;
        }
    }

	// Use this for initialization
	void Start () {
        foregroundImage = gameObject.GetComponent<Image>();
        percentage = percentage.GetComponent<Text>();

        // Add progression to depending on stars earned in Scenario 1
        if (Data.ScenarioWithMostStars(1).Stars > 0)
        {
            if (Data.ScenarioWithMostStars(1).Stars >= 1 && !Data.scenario1ProgStars[0])
            {
                Data.Progression += 8.466667f;
                Data.scenario1ProgStars[0] = true;
            }

            if (Data.ScenarioWithMostStars(1).Stars >= 2 && !Data.scenario1ProgStars[1])
            {
                Data.Progression += 8.466667f;
                Data.scenario1ProgStars[1] = true;
            }

            if (Data.ScenarioWithMostStars(1).Stars >= 3 && !Data.scenario1ProgStars[2])
            {
                Data.Progression += 8.466667f;
                Data.scenario1ProgStars[2] = true;
            }
        }

        // Add progression to depending on stars earned in Scenario 2
        if (Data.ScenarioWithMostStars(2).Stars > 0)
        {
            if (Data.ScenarioWithMostStars(2).Stars >= 1 && !Data.scenario2ProgStars[0])
            {
                Data.Progression += 8.466667f;
                Data.scenario2ProgStars[0] = true;
            }

            if (Data.ScenarioWithMostStars(2).Stars >= 2 && !Data.scenario2ProgStars[1])
            {
                Data.Progression += 8.466667f;
                Data.scenario2ProgStars[1] = true;
            }

            if (Data.ScenarioWithMostStars(2).Stars >= 3 && !Data.scenario2ProgStars[2])
            {
                Data.Progression += 8.466667f;
                Data.scenario2ProgStars[2] = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        value = Mathf.CeilToInt(Data.Progression);

        percentage.text = value.ToString() + "%";        
    }
}
