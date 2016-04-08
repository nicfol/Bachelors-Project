using UnityEngine;
using System.Collections;

public class ElaborationBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
    
}
