using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour {

    public Text achievementText;
    public GameObject panel;
    private Image panelImage;
    public float displayTime;
    public float fadeTime;

    Color transparentText;
    Color transparentPanel;

    Color showTextColor;
    Color showPanelColor;
    Color textColor;
    Color panelColor;

    private IEnumerator fadeAlpha;

    private static AchievementPopup achievementPopup;

    public static AchievementPopup Instance()
    {

        if (!achievementPopup)
        {
            achievementPopup = FindObjectOfType(typeof(AchievementPopup)) as AchievementPopup;
            if (!achievementPopup)
            {
                Debug.LogError("There needs to be one active AchievementPopup script on a GameObject in your scene.");
            }
        }
        return achievementPopup;
    }

    public void DisplayPopup(string achievementName)
    {
        achievementText.text = achievementName;
        SetAlpha();
    }

    void SetAlpha()
    {
        if(fadeAlpha != null)
        {
            StopCoroutine(fadeAlpha);
        }

        fadeAlpha = FadeAlpha();
        StartCoroutine(fadeAlpha);
    }

    IEnumerator FadeAlpha()
    {
        Color showTextColor = achievementText.color;
        Color resetTextColor = achievementText.color;
        resetTextColor.a = 0;
        achievementText.color = resetTextColor;


        Color panelColor = panelImage.color;
        Color showPanelColor = panelColor;
        Color resetPanelColor = panelColor;
        resetPanelColor.a = 0;
        panelImage.GetComponent<Image>().color = resetPanelColor;

        showTextColor.a = 1;
        showPanelColor.a = 0.25f;
        achievementText.color = showTextColor;
        panelImage.GetComponent<Image>().color = showPanelColor;

        yield return new WaitForSeconds(displayTime);



        while (achievementText.color.a > 0 && panelImage.GetComponent<Image>().color.a > 0)
        {
            Color displayTextColor = achievementText.color;
            Color displayPanelColor = panelImage.GetComponent<Image>().color;

            displayTextColor.a -= Time.deltaTime / fadeTime;
            achievementText.color = displayTextColor;

            displayPanelColor.a -= (Time.deltaTime / fadeTime) * 0.25f;
            panelImage.GetComponent<Image>().color = displayPanelColor;

            Debug.Log("TextColor: " + achievementText.color.ToString());
            Debug.Log("PanelColor: " + panelImage.GetComponent<Image>().color.ToString());

            yield return null;
        }

        yield return null;
    }

    // Use this for initialization
    void Start () {
        panelImage = panel.GetComponent<Image>();
        panelColor = panelImage.color;

        textColor = achievementText.color;

        showPanelColor = panelColor;
        showTextColor = textColor;

        transparentText = textColor;
        transparentText.a = 0;

        transparentPanel = panelColor;
        transparentPanel.a = 0;

        achievementText.color = transparentText;
        panelImage.GetComponent<Image>().color = transparentPanel;
	}
	
	// Update is called once per frame
	void Update () {

    }
}
