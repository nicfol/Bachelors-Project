using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public bool scenario_1 = false;
    public bool scenario_2 = false;

    private PlayerController player;

    string currentScene;

    [HideInInspector]
    public Scenario scenario;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Scenario 1" || currentScene == "Scenario 2")
        {
            player = GameObject.Find("Scenario Handler").GetComponent<PlayerController>();
            scenario = player.currentScenario;
        }
        else
        {
            if (scenario_1)
            {
                scenario = Data.ScenarioWithMostStars(1);
            }

            if (scenario_2)
            {
                scenario = Data.ScenarioWithMostStars(2);
            }
        }


    }

    // Update is called once per frame
    void Update () {
        if (scenario.Stars == 3)
        {
            // Show 3 stars
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (scenario.Stars == 2)
        {
            // Show 2 stars
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (scenario.Stars == 1)
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
