using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    private float speed = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move() {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;
        if (h > 0)  {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("Walk", true);

        }else if (h < 0){
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("Walk", true);
        }
        else if (h == 0){
            anim.SetBool("Walk", false);
        }

        transform.position = temp;
    }

    
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "stone")
        {
            Time.timeScale = 0f;
        }
    }


}
