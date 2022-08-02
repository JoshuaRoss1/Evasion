using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool dead = false;
    [System.NonSerialized]
    public int highestScore = 0; //Public so it can be accessed elsewhere (NonSerialized)
    [System.NonSerialized]
    public int score = 0; //Public so it can be accessed elsewhere (NonSerialized)
    public GameObject deathPanel;
    public GameObject scorePanel;
    public GameObject highScorePanel;
    private Text currentScore;
    private Text highScore;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        deathPanel.SetActive(false);
        scorePanel.SetActive(true);
        highScorePanel.SetActive(true);

        GameObject currentScorePanel = GameObject.Find("Score"); //Accessing UI text components
        currentScore = currentScorePanel.GetComponent<Text>();

        GameObject currentHighScorePanel = GameObject.Find("High Score"); 
        highScore = currentHighScorePanel.GetComponent<Text>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score"); 
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(score > PlayerPrefs.GetInt("High Score"))
        {
            highestScore = score;
            PlayerPrefs.SetInt("High Score", highestScore);
            highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        }
        
        if(player == null)
        {
            Dead();                     
        } else
        {
            currentScore.text = "Score: " + score;
        }
        Debug.Log(highestScore);  
    }

    public void Dead()
    {
        dead = true;
        deathPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        score = 0;
    }
}
