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

    Quaternion s1PlayerStartRotation;
    Quaternion s2PlayerStartRotation;
    Quaternion rot;
    Quaternion aedBackRotation;

    public float lerpTime = 1f;
    public float aedLerpTime = 0.4f;
    float currentLerpTime;

    private bool s1RotatePlayer = false;
    private bool hasRotatedOnce = false;
    private bool getAEDRotation = false;
    private Quaternion aedStartRotation;

    private bool s2RotatePlayer = false;
    private bool s2RotateEMT = false;
    private Quaternion s2PlayerEndRotation;
    private Quaternion emtStartRotation;
    private Quaternion emtEndRotation;

    private int question = 0;
    private int noOfQuestions;
    
    private int correctAnswers = 0;
    private int wrongAnswers = 0;
    
    private GameObject scenarioTextBox;
    
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
    private Quaternion s2PlayerFinalRotation;
    private bool s2RotatePlayerFinal;

    void Start () {
        newScenario = new Scenario();
        correctAnswerStreak = 0;
        endOfScenario = false;
        noWrongAnswer = true;

        currentLerpTime = 0;
       
        rot = Quaternion.Euler(0, 0, 105);
        s1PlayerStartRotation = player.transform.rotation;
        aedStartRotation = Quaternion.Euler(0, 0, 220);
        aedBackRotation = Quaternion.Euler(0, 0, 40);

        s2PlayerStartRotation = player.transform.rotation;
        s2PlayerEndRotation = Quaternion.Euler(0, 0, 270);
        s2PlayerFinalRotation = Quaternion.Euler(0, 0, 360);
        emtStartRotation = Quaternion.Euler(0, 0, -180);
        emtEndRotation = Quaternion.Euler(0,0,-90);

        // NEEDS TO CHECK WHICH SCENARIO WE ARE IN BEBORE ADDING TO A LIST !!!
        if(scenarioNumber == 1)
        {
            Data.scenario_1.Add(newScenario);
            currentScenario = Data.scenario_1[Data.scenario_1.Count - 1];
        }

        if(scenarioNumber == 2)
        {
            Data.scenario_2.Add(newScenario);
            currentScenario = Data.scenario_2[Data.scenario_2.Count - 1];
        }
        
        
        achievementPopup = achievementManager.GetComponent<AchievementPopup>();

        getNumberOfQuestions();
        
        scenarioTextBox = GameObject.Find("Scenario Text");
        scenarioTextBox.gameObject.SetActive(false);
        
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

    void Update() {
        if(scenarioNumber == 1) {
            if (s1RotatePlayer) {
                currentLerpTime += Time.deltaTime;

                if (currentLerpTime > lerpTime) {
                    s1PlayerStartRotation = rot;
                    currentLerpTime = 0;
                    s1RotatePlayer = false;
                }
                float perc = currentLerpTime / lerpTime;
                player.GetComponent<RectTransform>().rotation = Quaternion.Lerp(s1PlayerStartRotation, rot, perc);
            }

            if (getAEDRotation) {
                currentLerpTime += Time.deltaTime;

                if (currentLerpTime > lerpTime) {
                    currentLerpTime = 0;
                    getAEDRotation = false;
                }
                float perc = currentLerpTime / aedLerpTime;
                GameObject.Find("AEDPerson").GetComponent<RectTransform>().rotation = Quaternion.Lerp(aedStartRotation, aedBackRotation, perc);
            } else {
                GameObject.Find("AEDPerson").GetComponent<RectTransform>().rotation = aedStartRotation;
            }
        } else if (scenarioNumber == 2) {
            // Rotate player towards Dead Person in the beginning
            if (s2RotatePlayer && player.GetComponent<RectTransform>().anchoredPosition.y > -20)
            {
                currentLerpTime += Time.deltaTime;

                if (currentLerpTime > lerpTime)
                {
                    s2PlayerStartRotation = s2PlayerEndRotation;
                    currentLerpTime = 0;
                    s2RotatePlayer = false; 
                    s2RotatePlayerFinal = true;
                }
                float perc = currentLerpTime / lerpTime;
                player.GetComponent<RectTransform>().rotation = Quaternion.Lerp(s2PlayerStartRotation, s2PlayerEndRotation, perc);
            }

            // Rotate player towards EMT's in the end
            if (s2RotatePlayerFinal && player.GetComponent<RectTransform>().anchoredPosition.y > -15)
            {
                currentLerpTime += Time.deltaTime;

                if (currentLerpTime > lerpTime)
                {
                    s2PlayerStartRotation = s2PlayerFinalRotation;
                    currentLerpTime = 0;
                    s2RotatePlayer = false;
                }
                float perc = currentLerpTime / lerpTime;
                player.GetComponent<RectTransform>().rotation = Quaternion.Lerp(s2PlayerStartRotation, s2PlayerFinalRotation, perc);
            }

            // Rotate EMT'S
            if (s2RotateEMT)
            {
                currentLerpTime += Time.deltaTime;

                if (currentLerpTime > lerpTime)
                {
                    currentLerpTime = lerpTime;
                    emtStartRotation = emtEndRotation;
                    //currentLerpTime = 0;
                    s2RotateEMT = false;
                }
                float perc = currentLerpTime / aedLerpTime;
                for(int i = 1; i < 3; i++)
                {
                    GameObject.Find("EMT" + i).GetComponent<RectTransform>().rotation = Quaternion.Lerp(emtStartRotation, emtEndRotation, perc);
                }
                
            }
        } else {
            Debug.Log("Scenario Number not properly specified!");
        }
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
        
        if(scenarioNumber == 1) {
            //Scenario 1 code here
            
            if (question == noOfQuestions) {
                GameObject.Find("BackButton").gameObject.SetActive(false);
                GameObject.Find("Scenario Text").gameObject.SetActive(false);
                StartCoroutine("queAmbulance");
                question++;
            } else if (question == noOfQuestions + 1) {                
                endOfScenario = true;
                EndSceneObject.gameObject.SetActive(true);  //Enables the end scene canvas            
            } else if(question <= noOfQuestions) {
                StartCoroutine("nextQuestion");
                if (question == 0) {
                
                } else if (question == 2) {
                    //Rotate player
                    s1RotatePlayer = true;

                    //Move him to his idle position
                    StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 1"), 4.0f));
                } else if(question == 8) {
                    //Get AED
                    StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 2"), 1.0f));
                    getAEDRotation = true;

                } else if(question == 10) {
                    //Return with AED
                    getAEDRotation = false;
                    StartCoroutine(moveObject(GameObject.Find("AEDPerson"), GameObject.Find("AEDPerson Target 3"), 1.0f));                
                }
            }
        } else if (scenarioNumber == 2) {
            //Scenario 2 code here            
            if (question == noOfQuestions) { 
                GameObject.Find("BackButton").gameObject.SetActive(false);
                GameObject.Find("Scenario Text").gameObject.SetActive(false);
                
                StartCoroutine("queAmbulance");
                question++;

            } else if(question == noOfQuestions + 1) { 
                endOfScenario = true;
                EndSceneObject.gameObject.SetActive(true);  //Enables the end scene canvas            
            } else if(question <= noOfQuestions) {
                StartCoroutine("nextQuestion");
                if (question == 0) {
                    Debug.Log("90 to left");
                    // Rotate player 90 degrees left
                    s2RotatePlayer = true;

                } else if(question == 10) {
                    Debug.Log("90 to left");
                    // Rotate player 90 degrees left
                    
                }
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
            GameObject EMTS = GameObject.Find("EMTS");
            GameObject deadPerson = GameObject.Find("Dead Person");
            
            GameObject emtTar1 = GameObject.Find("EMT Target 1");
            
        //THIS IS DISGUSTING
        if(scenarioNumber == 1) {
        
            GameObject ambulance = GameObject.Find("Ambulance");
            
            GameObject emtTar2 = GameObject.Find("EMT Target 2");
            
            GameObject AmbTar1 = GameObject.Find("Ambulance Target 1");
            GameObject AmbTar2 = GameObject.Find("Ambulance Target 2");

            StartCoroutine(moveObject(ambulance, AmbTar1, 2.0f));
            ambulance.GetComponent<AudioSource>().PlayDelayed(1.7f);
            yield return StartCoroutine(moveObject(EMTS, AmbTar1, 2.0f));
            yield return StartCoroutine(moveObject(EMTS, emtTar1, 1f));
            
            StartCoroutine(moveObject(EMTS, emtTar2, 1f));
            yield return StartCoroutine(moveObject(deadPerson, emtTar2, 1f));
            
            StartCoroutine(moveObject(ambulance, AmbTar2, 2f));
            StartCoroutine(moveObject(deadPerson, AmbTar2, 2f));
            yield return StartCoroutine(moveObject(EMTS, AmbTar2, 2f));
            
            startNextQuestion();
        } else if (scenarioNumber == 2) {
                
            StartCoroutine(moveObject(player, GameObject.Find("Player Target (1)"), 1.25f));
            yield return StartCoroutine(moveObject(EMTS, emtTar1, 1.0f));
            startNextQuestion();

            /*
            // EMT1 rotate 90 degrees left
            */
            s2RotateEMT = true;
            /*
            // EMT2 rotate 90 degrees left
            */
        }    
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
                            
            if(cameraTargets[question] != null) {   //Moves the camera to the next target, if it's not null
                cam.transform.position = Vector3.Lerp(camStartingPos, cameraTargets[question].position, t);
                
                //Changes the cameras zoom if it's not null, not equals to the current zoom and not equals zero
                if(camZoom[question] != null && cam.orthographicSize != camZoom[question] && camZoom[question] != 0.0f) {
                    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camZoom[question], t/20);   //Zooms the camera
                }                
            }
            yield return null;
        }
        
        if(question == 0) {
            scenarioTextBox.gameObject.SetActive(true);
        }
        
        questionObjects[question].gameObject.SetActive(true);   //Enables the answers for the next question
        question ++;  //Adds one to the question so we can move on to the next question
        
    }
        
}