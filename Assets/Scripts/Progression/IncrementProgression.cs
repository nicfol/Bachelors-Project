using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class IncrementProgression : MonoBehaviour {

    string sceneName;
    bool hasBeenVisited;
    private float incrementValue;
    
    void Start()
    {
        incrementValue = 7f;
        sceneName = SceneManager.GetActiveScene().name;
        if (!Data.Scenes.Any(str => str.Contains(sceneName)))
        {
            Data.Progression += incrementValue;
            Data.Scenes.Add(sceneName);
        }
    }

    
}
