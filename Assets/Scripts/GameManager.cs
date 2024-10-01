using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool isGamePaused = false;

    bool endGame = false;
    bool win = false;

    public int points;

    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stopper", 2,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && endGame == false)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        PickUpCheck();
    }
    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        isGamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if(timeToEnd <= 0)
        {
            endGame = true;
        }
        if(endGame)
        {
            GameEnd();
        }

    }

    void GameEnd()
    {
        CancelInvoke("Stopper");

        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }
    
    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int addedTime)
    {
        timeToEnd += addedTime;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating(nameof(Stopper), freeze, 1);
    }
    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
        {
            redKeys++;
        }
        else if(color == KeyColor.Green)
        {
            greenKeys++;
        }
        else if(color == KeyColor.Gold)
        {
            goldKeys++;
        }
    }

    void PickUpCheck()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKeys + " green: " + greenKeys + " gold: " + goldKeys);
            Debug.Log("Points: " + points);
        }
    }
}
