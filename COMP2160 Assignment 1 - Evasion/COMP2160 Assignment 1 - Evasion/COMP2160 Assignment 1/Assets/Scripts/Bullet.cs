using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 0.0f;
    [System.NonSerialized]
    public Vector3 direction = Vector3.zero; //Public so it can be accessed elsewhere (NonSerialized)
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
        
    }

    void OnBecameInvisible() //Destroys gameobject when it no longer becomes visible (off screen)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        Destroy(collider.gameObject);
    }
}
