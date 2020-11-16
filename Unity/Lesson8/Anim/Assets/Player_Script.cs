using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public bool isRightSide = true;
    public float speed;
    private bool isGrounded = false;
    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
       // GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        /*
       // rb.MovePosition(rb.position + Vector2.right * moveX * speed); 

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
        */
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //прикладываем силу вверх, чтобы персонаж подпрыгнул
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed,40);
            isGrounded = false;
        }
        if (isGrounded && moveX !=0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, 0);
        }
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            isGrounded = true;
        }
    }
}
