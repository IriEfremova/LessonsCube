using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public bool isRightSide = true;
    public int speed;
    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position + Vector2.right * moveX * speed); 

        if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide))
        {  
          
            if (moveX != 0f) //Если он не стоит
            {
                isRightSide = !isRightSide;
                transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
            }
        }
        if(moveX != 0F)
            GetComponent<Animator>().SetBool("isWalk", true);
        else
            GetComponent<Animator>().SetBool("isWalk", false);

    }
}
