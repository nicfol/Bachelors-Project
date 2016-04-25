using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public bool scenario_1 = false;
    public bool scenario_2 = false;

    private Scenario s;

	// Use this for initialization
	void Start () {
        s = new Scenario();
        if (scenario_1)
        {
            s = Data.scenario_1;
        } else if (scenario_2)
        {
            s = Data.scenario_2;
        }
        else
        {
            Debug.Log("Stars script: You forgot to select scenario.");
        }
    }

    // Update is called once per frame
    void Update () {
        if (s.Stars == 3)
        {
            // Show 3 stars
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (s.Stars == 2)
        {
            // Show 2 stars
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (s.Stars == 1)
        {
            // Show 1 star  
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else
        {
            // Show no star
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
}
