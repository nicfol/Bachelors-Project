using UnityEngine;
using System.Collections;

public class Heartbeat : MonoBehaviour {

    private bool hasTapped = false;
    private float timePassed;
    private bool start = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.S))
        {
            start = true;
            timePassed = 0;
        }

        if (start)
        {
            if (timePassed <= 30)
            {
                timePassed += Time.deltaTime;
            }

            Debug.Log(timePassed);



        }    
	}

    public void TapHeart()
    {
        hasTapped = true;
    }
}
