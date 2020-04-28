using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Fruit;

    private float min_X = -2.5f;
    private float max_X = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        GameObject k = Instantiate(Fruit);

        float x = Random.Range(min_X, max_X);
        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
