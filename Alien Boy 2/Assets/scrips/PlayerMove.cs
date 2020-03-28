using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private SpriteRenderer sr;

    private float speed = 3f;

    private float min_X = -2.5f;
    private float max_X = 2.5f;

    public Text timer_Text;
    private int timer;
    private object collision;

    Vector3 Destination = Vector3.zero;

    public GameManager _manager;
    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Destination = gameObject.transform.position;
    }

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,Destination,10*Time.deltaTime);

    }

    public void ChangePos(float pos)
    {
        Destination = new Vector3(pos, Destination.y, Destination.z);
    }



    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

    IEnumerator CountTime()
    {

        yield return new WaitForSeconds(1f);
        timer++;

        timer_Text.text = "Score : " + timer;

        StartCoroutine(CountTime());
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {

        if (other.tag == "sezer")
        {
            GameObject.Find("Sound").GetComponent<Sound>().hit.Play();
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("Score") < timer)
            {
                PlayerPrefs.SetInt("Score", timer);
            }
            _manager.Score = timer;
            _manager.pauseGame();
            //StartCoroutine(RestartGame());
        }
        if (other.tag == "coin")
        {
            GameObject.Find("Sound").GetComponent<Sound>().collect.Play();
            Destroy(other.gameObject);
            timer += 2;
        }


    }
}