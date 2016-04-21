using UnityEngine;
using System.Collections;

public class ShowHide : MonoBehaviour {

    public bool disableOnStart = true;
    
	// Use this for initialization
	void Start () {
	    if(disableOnStart) {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void showhideGO() {
    
        if(gameObject.activeSelf == true) {
            gameObject.SetActive(false);
        } else if(gameObject.activeSelf == false) {
            gameObject.SetActive(true);   
        }
    }
    
    public void disableGO(){
        if(gameObject.activeSelf == true) {
            gameObject.SetActive(false);
        } else {
            //Do nothing
        }
    }
    
    public void activateGO() {
        if(gameObject.activeSelf == false) {
            gameObject.SetActive(true);
        } else {
            //Do nothing
        }
    }
    
}
