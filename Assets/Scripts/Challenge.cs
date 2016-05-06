using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Challenge : MonoBehaviour {

    public GameObject previousChallenge;
    private GameObject overlay;
    
    void Start()
    {
        previousChallenge.GetComponent<Stars>();
        overlay = this.gameObject.transform.FindChild("Lock_Overlay").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	    if(previousChallenge.GetComponent<Stars>().scenario.Stars >= 2)
        {
            overlay.SetActive(false);
            GameObject.Find("Challenge_2").gameObject.GetComponent<Selectable>().interactable = true;
        }
        else
        {
            overlay.SetActive(true);
            GameObject.Find("Challenge_2").gameObject.GetComponent<Selectable>().interactable = false;
        }
	}
}
