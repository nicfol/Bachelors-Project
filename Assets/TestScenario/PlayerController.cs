using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public Transform[] playerTargets;
    public Transform[] cameraTargets;
    private int question = 0;
    
    private float transitionDuration = 2.5f;

	// Use this for initialization
	void Start () {
	    StartCoroutine("movePlayer");
	}
	
	// Update is called once per frame
	void Update () {        
        Debug.Log(question + " " + transitionDuration);
                
        if (question == 1) {
            transitionDuration = 1.0f;
        }
            
        if(Input.GetKeyDown("space")) {
            StartCoroutine("movePlayer");
        }
	}
    
      
    IEnumerator movePlayer() {
            
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        Vector3 camStartingPos = Camera.main.transform.position;
        while (t < 1.0f) {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            transform.position = Vector3.Lerp(startingPos, playerTargets[question].position, t);
            
            if(question == 0) {
                Camera.main.transform.position = Vector3.Lerp(camStartingPos, cameraTargets[question].position, t);
            } else if (question == 1) {
                Camera.main.transform.position = Vector3.Lerp(camStartingPos, cameraTargets[question].position, t);
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2, t/20);
            }
            yield return null;
        }
        question += 1;
    }
    
}
