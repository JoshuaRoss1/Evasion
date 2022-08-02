using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 0.0f;
     
    // Update is called once per frame
    void Update()
    {     
        if(Input.GetKey(KeyCode.A)) //Left = a, Right = d
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);               
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);   
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);   
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);   
        }
        
    }
}
