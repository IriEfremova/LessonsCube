using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject jump_animation;
    public int speedH;
    public int speedV;
    bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dH = Input.GetAxis("Horizontal");
        float dV = Input.GetAxis("Vertical");

        /*
        if(dV != 0 && isJump == false)
        {
            isJump = true;
            Instantiate(jump_animation, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
        */
        if (dV > 0 && isJump == false)
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speedV));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedV );
            isJump = true;
            Debug.Log("Jump");
        }
        if(dH != 0 && isJump == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(dH * speedH, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Land"))
        {
            collision.isTrigger = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Land"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Fish")) {
            transform.parent = collision.transform;
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            transform.parent = null;
        }
    }
}
