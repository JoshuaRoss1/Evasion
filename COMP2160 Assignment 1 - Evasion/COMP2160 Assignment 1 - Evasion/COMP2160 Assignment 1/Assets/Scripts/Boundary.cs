using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    //Couldn't figure out how to keep player in bounds, after some research this was the solution that I found. 
    //Full credit to Waldo of Press Start: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 
                Screen.height, Camera.main.transform.position.z)); //Half of screen width and height in world coordinates

        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //Calculating object bounds
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        //Clamping object into bound of screen
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth); 
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = viewPos;
    }
    
}
