using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject player;
    public Camera cam;

    private int question = 0;
    private int noOfQuestions;
    
    public Transform[] playerTargets;
    public Transform[] cameraTargets;
    public float[] camZoom;
    
    public GameObject[] questionObjects;

    private float transitionDuration = 2.5f;

	void Start () {
        getNumberOfQuestions();
        
        if(cam == null) {
            cam = Camera.main;
        }
        if (player == null) {
            player = GameObject.Find("Player");
        }
        
	    startMovePlayer();
	}
	
	void Update () {        
        Debug.Log(question + " " + transitionDuration);
            
        if(Input.GetKeyDown("space")) {
            startMovePlayer();
        }
        
	}
    
    public void getNumberOfQuestions() {
        noOfQuestions = GameObject.Find("QuestionBoxes(Canvas)").transform.childCount;
        Debug.Log("No of questions: " + noOfQuestions);
    }
    
    public void startMovePlayer() {
        if(question != 0) {
            questionObjects[question].gameObject.SetActive(false);
        }
        StartCoroutine("movePlayer");
    }
    
    IEnumerator movePlayer() {
                
        //Change camera movement speed after intro scene
        if(question == 1.0f) {
            transitionDuration = 1.0f;
        }
                
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
        questionObjects[question].gameObject.SetActive(true);
        question += 1;
    }
    
}
