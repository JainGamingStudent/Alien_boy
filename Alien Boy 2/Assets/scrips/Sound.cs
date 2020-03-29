using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource collect;
    
    public void quitApplication()
    {
        Application.Quit();
    }
}
