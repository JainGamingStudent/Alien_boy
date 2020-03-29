using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadnextScene(string name)
    {
        // DontDestroyOnLoad(GameObject.Find("Sound"));
        SceneManager.LoadScene(name);
        
    }
}
