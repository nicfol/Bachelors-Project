using UnityEngine;
using System.Collections;

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
        }
        else
        {
            overlay.SetActive(true);
        }
	}
}
