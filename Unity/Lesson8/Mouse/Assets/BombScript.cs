using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BombScript : MonoBehaviour
{
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown Player" + Input.mousePosition.x + "  " + Input.mousePosition.y);
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }
}
