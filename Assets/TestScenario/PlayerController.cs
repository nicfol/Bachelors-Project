using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject player;
    public Camera cam;
    
    public Transform[] playerTargets;
    public Transform[] cameraTargets;
    public float[] camZoom;
    
    private int question = 0;

    private float transitionDuration = 2.5f;

	// Use this for initialization
	void Start () {
        if(cam == null) {
            cam = Camera.main;
        }
        if (player == null) {
            player = GameObject.Find("Player");
        }
        
	    StartCoroutine("movePlayer");
	}
	
	// Update is called once per frame
	void Update () {        
        Debug.Log(question + " " + transitionDuration);
            
        if(Input.GetKeyDown("space")) {
            StartCoroutine("movePlayer");
        }
	}
    
    public static void startMovePlayer() {
        StartCoroutine("movePlayer");
    }
    
    IEnumerator movePlayer() {
        float t = 0.0f;
        Vector3 startingPos = player.transform.position;
        Vector3 camStartingPos = cam.transform.position;
        while (t < 1.0f) {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            
            if(playerTargets[question] != null) {
                player.transform.position = Vector3.Lerp(startingPos, playerTargets[question].position, t);
            }
            
            if(cameraTargets[question] != null) {
                cam.transform.position = Vector3.Lerp(camStartingPos, cameraTargets[question].position, t);
                
                if(camZoom[question] != null && cam.orthographicSize != camZoom[question]) {
                    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camZoom[question], t/20);
                }                
            }
            yield return null;
        }
        question += 1;
    }
    
}
