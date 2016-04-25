using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject player;
    public Camera cam;
    
    public GameObject correctBox;
    public GameObject EndSceneObject;

    private int question = 0;
    private int noOfQuestions;
    
    private int correctAnswers = 0;
    private int wrongAnswers = 0;
    
    public Transform[] playerTargets;
    public Transform[] cameraTargets;
    public float[] camZoom;
    
    public GameObject[] questionObjects;

    private float transitionDuration = 2.5f;
    
	void Start () {
        getNumberOfQuestions();
        
        //Automatically set camera and player if they aren't       
        if(cam == null) {
            cam = Camera.main;
        }
        if (player == null) {
            player = GameObject.Find("Player");
        }
        
        // ------- HACK ------- //
            // SHOW ERROR IF playerTargets[], cameraTargets[] or camZoom[] LENGTH DOES NOT 
            // EQUAL THE AMOUNT OF QUESTIONS IN noOfQuestions
            if (playerTargets.Length != noOfQuestions || cameraTargets.Length != noOfQuestions || camZoom.Length != noOfQuestions) {
                Debug.Log("playerTargets[], cameraTargets[] or camZoom[] LENGTH IS NOT THE SAME AS noOfQuestions"); 
                playerTargets[40] = playerTargets[41];
            }
        // ------- HACK ------- //
        
        //Starts the scenario
	    startNextQuestion();
	}
    
    //Finds the number of questions based on the number of child gameobjects from "QuestionBoxes(Canvas)"
    public void getNumberOfQuestions() {
        noOfQuestions = GameObject.Find("Answer Options").transform.childCount;
        Debug.Log("No of questions: " + noOfQuestions);
    }
    
    //Add one to wrongAnswers
    public void addToWrongAnswer() {
        wrongAnswers++;
        Debug.Log("Added one to wrongAnswers");
    }
    
    //Add one to correctAnswers
    public void addToCorrectAnswer() {
        correctAnswers++;
        Debug.Log("Added one to correctAnswers");
    }
    
    //Method to start the coroutine nextQuestion
    public void startNextQuestion() {
        Debug.Log(question);
        StartCoroutine("nextQuestion");
    }
    
    IEnumerator nextQuestion() {  
        //Change camera movement speed after intro scene
        if(question == 1.0f) {
            transitionDuration = 1.0f;
        }
        
        if (question == noOfQuestions) {
            EndSceneObject.gameObject.SetActive(true);
            Debug.Log("W: " + wrongAnswers + " | C: " + correctAnswers);
        } else if(question <= noOfQuestions) {        
            float t = 0.0f;
            Vector3 startingPos = player.transform.position;
            Vector3 camStartingPos = cam.transform.position;
            while (t < 1.0f) {
                t += Time.deltaTime * (Time.timeScale/transitionDuration);
                
                if(t > 1) {
                    correctBox.gameObject.SetActive(false);
                }
                
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
    
}
