using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private GameObject ui;
    [System.NonSerialized]
    public int highScore = 0; //Public so it can be accessed elsewhere (NonSerialized)
    
    // Start is called before the first frame update
    void Start()
    {
     ui = GameObject.Find("UI Manager");   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        if(ui.GetComponent<UIManager>().score > highScore)
        {
            highScore = ui.GetComponent<UIManager>().score;
        }
    }
}
