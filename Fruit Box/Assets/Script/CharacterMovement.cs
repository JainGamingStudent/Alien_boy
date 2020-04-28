using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float characterMoveSpeed;
    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        characterMoveSpeed = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * characterMoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        
    }
}
