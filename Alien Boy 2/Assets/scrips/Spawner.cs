using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sezer;
    public GameObject coin;

    private float min_X = -2.5f;
    private float max_X = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 0.5f));
        GameObject k;
        if (Random.Range(0f, 10f) > 5)
        {
            k = Instantiate(sezer);
        }
        else
        {
            k = Instantiate(coin);
        }

        if (Random.Range(min_X, max_X) > 0)
        {
            k.transform.position = new Vector2(1.5f, transform.position.y);
        }
        else
        {
            k.transform.position = new Vector2(-1.5f, transform.position.y);
        }
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
