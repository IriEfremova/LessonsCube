using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject jump_animation;
    public int speedH;
    public int speedV;
    bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dH = Input.GetAxis("Horizontal");
        //float dV = Input.GetAxis("Vertical");
        bool dV = Input.GetKeyDown(KeyCode.UpArrow);

        /*
        if(dV != 0 && isJump == false)
        {
            isJump = true;
            Instantiate(jump_animation, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
        */
        if (dV && isGround == true)
        {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedV);
                isGround = false;
        }
        if(dH != 0 && isGround == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(dH * speedH, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Land"))
        {
            Debug.Log(collision.gameObject.name);
            collision.isTrigger = false;
            Debug.Log("NOT TRIGGER");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Fish")) {
            transform.parent = collision.transform;
            isGround = true;
         }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            transform.parent = null;
            isGround = false;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Debug.Log("Fish TRIGGER");
        }
        if (collision.gameObject.CompareTag("Land"))
        {
            isGround = false;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Debug.Log("Land TRIGGER");
        }
    }
}
