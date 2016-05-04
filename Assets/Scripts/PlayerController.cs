using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject player;
    public Camera cam;

    public GameObject achievementManager;
    private AchievementPopup achievementPopup;

    public GameObject correctBox;
    public GameObject wrongBox;
    public GameObject EndSceneObject;
    public GameObject AnswerOptionsObject;

    private int question = 0;
    private int noOfQuestions;
    
    private int correctAnswers = 0;
    private int wrongAnswers = 0;
    
    public GameObject[] questionObjects;
    
    public Transform[] playerTargets;
    public Transform[] cameraTargets;
    public float[] camZoom;
    public Transform[] playerRotations;
    
    public GameObject settingText;

    public int scenarioNumber;

    [HideInInspector]
    private Scenario newScenario;
    public Scenario currentScenario;

    public int threeStarsMin = 12;
    public int twoStarsMin = 9;
    public int oneStarMin = 7;

    [HideInInspector]
    public int correctAnswerStreak;

    [HideInInspector]
    public bool noWrongAnswer;
    [HideInInspector]
    public bool endOfScenario;

    private float transitionDuration = 2.5f;
    
	void Start () {
        newScenario = new Scenario();
        correctAnswerStreak = 0;
        endOfScenario = false;
        noWrongAnswer = true;

        // NEEDS TO CHECK WHICH SCENARIO WE ARE IN BEBORE ADDING TO A LIST !!!
        Data.scenario_1.Add(newScenario);
        currentScenario = Data.scenario_1[Data.scenario_1.Count - 1];

        achievementPopup = achievementManager.GetComponent<AchievementPopup>();

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
        //StartCoroutine("queAmbulance");   
	}
    
    //Finds the number of questions based on the number of child gameobjects from "QuestionBoxes(Canvas)"
    public void getNumberOfQuestions() {
        //noOfQuestions = GameObject.Find("Answer Options").transform.childCount;
        noOfQuestions = AnswerOptionsObject.transform.childCount;
        Debug.Log("No of questions: " + noOfQuestions);
    }
    
    //Add one to wrongAnswers
    public void addToWrongAnswer() {
        currentScenario.wrongAnswers++;
        currentScenario.totalAnswers++;
        correctAnswerStreak = 0;
        noWrongAnswer = false;
        Debug.Log("Added one to wrongAnswers");
    }
    
    //Add one to correctAnswers
    public void addToCorrectAnswer() {
        currentScenario.correctAnswers++;
        currentScenario.totalAnswers++;
        correctAnswerStreak++;
        Debug.Log("Added one to correctAnswers");
    }
    
    //Method to start the coroutine nextQuestion
    public void startNextQuestion() {
        Debug.Log(question);
        
        if (question == noOfQuestions) {
            StartCoroutine("queAmbulance");
            question++;
        } else if (question == noOfQuestions + 1) {
            endOfScenario = true;
            EndSceneObject.gameObject.SetActive(true);  //Enables the end scene canvas            
        } else if(question <= noOfQuestions) {
            StartCoroutine("nextQuestion");
            if (question == 2) {
                //Move him to his idle position
                StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 1"), 4.0f));
            } else if(question == 8) {
                //Get AED
                StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 2"), 1.0f));
            } else if(question == 10) {
                //Return with AED
                StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 3"), 1.0f));                
            }
        }
    }
    
    IEnumerator moveObject(GameObject Obj2Move, GameObject targetObj, float timeScalar) {
        GameObject moveObj = GameObject.Find(Obj2Move.name);
        Vector3 startingPos = moveObj.transform.position;
        Vector3 target = targetObj.transform.position; 
                
        float t = 0.0f;
        while(t < 1.0f) {
            t += Time.deltaTime * (Time.timeScale/transitionDuration/timeScalar);  //Progress in time
            
            moveObj.transform.position = Vector3.Lerp(startingPos, target, t);
            yield return null;
        } 
    }
        
    IEnumerator queAmbulance() {
        
        //THIS IS DISGUSTING
        
        GameObject ambulance = GameObject.Find("Ambulance");
        GameObject EMTS = GameObject.Find("EMTS");
        GameObject deadPerson = GameObject.Find("Dead Person");
        
        GameObject AmbTar1 = GameObject.Find("Ambulance Target 1");
        GameObject AmbTar2 = GameObject.Find("Ambulance Target 2");
        
        GameObject emtTar2 = GameObject.Find("EMT Target 2");
        
        StartCoroutine(moveObject(ambulance, AmbTar1, 1.0f));
        yield return StartCoroutine(moveObject(EMTS, AmbTar1, 1.0f));
        yield return StartCoroutine(moveObject(EMTS, GameObject.Find("EMT Target 1"), 0.25f));
        
        StartCoroutine(moveObject(EMTS, emtTar2, 0.25f));
        yield return StartCoroutine(moveObject(deadPerson, emtTar2, 0.25f));
        
        StartCoroutine(moveObject(ambulance, AmbTar2, 0.25f));
        StartCoroutine(moveObject(deadPerson, AmbTar2, 0.25f));
        yield return StartCoroutine(moveObject(EMTS, AmbTar2, 0.25f));
        
        startNextQuestion();
        
        Debug.Log("queAmbulance done");

        yield return null;
    }

    
    IEnumerator nextQuestion() {        
        //Disable wrong option box + children
        wrongBox.gameObject.SetActive(false);
        for( int i = 0; i < wrongBox.transform.GetChild(0).transform.GetChild(0).transform.childCount; ++i ) {
            wrongBox.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).gameObject.SetActiveRecursively(false);
        }       
          
        //Change camera movement speed after intro scene
        if(question == 1.0f) {
            transitionDuration = 1.0f;
        }
                    
        //Disable and enable next setting text in the top
        if(question != 0) {
            settingText.transform.GetChild(question-1).gameObject.SetActive(false);
            settingText.transform.GetChild(question).gameObject.SetActive(true);
        }
        float t = 0.0f;
        Vector3 startingPos = player.transform.position;    //Save the players starting position
        Vector3 camStartingPos = cam.transform.position;    //Save the cameras starting position
                        
        while (t < 1.0f && cam.transform.position != cameraTargets[question].position) {
            
            t += Time.deltaTime * (Time.timeScale/transitionDuration);  //Progress in time
            
            if(t > 1) { //Set the correct answer box to disabled
                correctBox.gameObject.SetActive(false);
            }
            
            if(playerTargets[question] != null) {   //Moves the player to the next target, if it's not null
                player.transform.position = Vector3.Lerp(startingPos, playerTargets[question].position, t);
            }
            
            /* SHIT ISN'T WORKING
            if(playerRotations[question] != null && t > 0.95f) {
                Vector3 dir = playerRotations[question].position - player.transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                Debug.Log(angle);
                player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);                           
            }
            */
                            
            if(cameraTargets[question] != null) {   //Moves the camera to the next target, if it's not null
                cam.transform.position = Vector3.Lerp(camStartingPos, cameraTargets[question].position, t);
                
                //Changes the cameras zoom if it's not null, not equals to the current zoom and not equals zero
                if(camZoom[question] != null && cam.orthographicSize != camZoom[question] && camZoom[question] != 0.0f) {
                    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camZoom[question], t/20);   //Zooms the camera
                }                
            }
            yield return null;
        }

        questionObjects[question].gameObject.SetActive(true);   //Enables the answers for the next question
        question ++;  //Adds one to the question so we can move on to the next question
        
    }
        
}