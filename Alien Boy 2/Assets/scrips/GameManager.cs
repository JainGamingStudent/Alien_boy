using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Score_txt;
    public Text bestScore_txt;
    public int Score;

    public GameObject gameover;

    public GameObject pausebtn;
    public GameObject resumebtn;
    public void pauseGame()
    {
        pausebtn.SetActive(false);
        bestScore_txt.text = "Best Score : " + PlayerPrefs.GetInt("Score");
        Score_txt.text = "Current Score : " + Score;
        gameover.SetActive(true);

    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void pauseGameScene()
    {
        pausebtn.SetActive(false);
        resumebtn.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumeGame_pause()
    {
        pausebtn.SetActive(true);
        resumebtn.SetActive(false);
        Time.timeScale = 1;
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            pauseGameScene();
        }
    }

}
