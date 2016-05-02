using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class IncrementProgression : MonoBehaviour {

    string sceneName;
    bool hasBeenVisited;
    int incrementValue;
    
    void Start()
    {
        incrementValue = 4;
        sceneName = SceneManager.GetActiveScene().name;
        
        if (!Data.Scenes.Any(str => str.Contains(sceneName)))
        {
            Data.Scenes.Add(sceneName);
            Data.Progression += incrementValue;
        }
    }

    
}
