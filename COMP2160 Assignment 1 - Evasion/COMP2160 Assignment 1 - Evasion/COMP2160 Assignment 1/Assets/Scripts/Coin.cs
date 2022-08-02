using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    private GameObject uiManager;

    public float disappearTime = 0.0f;
    private float timer = 0.0f;
    
    void Start()
    {
        player = GameObject.Find("Player");
        uiManager = GameObject.Find("UI Manager");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= disappearTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        uiManager.GetComponent<UIManager>().score++;
    }
}
