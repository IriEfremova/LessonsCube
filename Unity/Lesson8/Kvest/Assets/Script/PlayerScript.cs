using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject splash;
    public int speedH;
    public int speedV;
    bool isGround = true;
    public Sprite lose;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
        if (dH != 0 && isGround == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(dH * speedH, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish") || collision.gameObject.CompareTag("Stone"))
        {
            Debug.Log(collision.gameObject.name);
            collision.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("LandEnd"))
        {
            Debug.Log(collision.gameObject.name);
            collision.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            //Sprite sp = new Sprite("");
            //sprites = Resources.LoadAll<Sprite>(spriteNames);
            Debug.Log("WATER" + GetComponent<SpriteRenderer>().sortingOrder);
            Instantiate(splash, transform.position, transform.rotation);
            GetComponent<SpriteRenderer>().sprite = lose;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            isGround = true;
            GameObject.Find("fish_green").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("fish_red").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("stoun_01").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("land_top").GetComponent<Collider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Stone"))
        {
            isGround = true;
            GameObject.Find("fish_green").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("fish_red").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("land_top").GetComponent<Collider2D>().isTrigger = true;
        }
        if (collision.gameObject.CompareTag("LandEnd"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Fish"))
        {
            transform.parent = collision.transform;
            isGround = true;
            GameObject.Find("land_top").GetComponent<Collider2D>().isTrigger = true;
            GameObject.Find("stoun_01").GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            transform.parent = null;
            isGround = false;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        if (collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("LandEnd"))
        {
            isGround = false;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}

