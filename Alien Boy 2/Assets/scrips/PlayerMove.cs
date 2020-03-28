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

    Vector3 rightLook = new Vector3(1, 1, 1);
    Vector3 leftLook = new Vector3(-1, 1, 1);
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
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,Destination,5*Time.deltaTime);
        if(Vector3.Distance(gameObject.transform.position,Destination)<0.01f)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Destination.x = pos.x;
            if (gameObject.transform.position.x < Destination.x)
            {
                gameObject.transform.localScale = rightLook;
            }
            else
            {
                gameObject.transform.localScale = leftLook;
            }
        }

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
           // GameObject.Find("Sound").GetComponent<Sound>().hit.Play();
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("Score") < timer)
            {
                PlayerPrefs.SetInt("Score", timer);
            }
            _manager.Score = timer;
            _manager.GameOverScreen();
            //StartCoroutine(RestartGame());
        }
        if (other.tag == "coin")
        {
           // GameObject.Find("Sound").GetComponent<Sound>().collect.Play();
            Destroy(other.gameObject);
            timer += 2;
        }


    }
}