using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    Image foregroundImage;
    public Text percentage;

    int value
    {
        get
        {
            if (foregroundImage != null)
                return (int)(foregroundImage.fillAmount * 100);
            else
                return 0;
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
    }
	
	// Update is called once per frame
	void Update () {
        percentage.text = value.ToString() + "%";
        value = Data.Progression;
    }
}
