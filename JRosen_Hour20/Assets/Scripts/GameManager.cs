using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextureScroller ground;
    public float gameTime = 10f;

    float totalTimeElapsed = 0;

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            isGameOver = true;
        }
    }

    void SpeedWorldUp()
    {
        Time.timeScale = 1f;
    }

    public void IncreaseDifficulty(float num)
    {
        Time.timeScale += num;
    }

    void SlowWorldDown()
    {
        // Cancel any invokes to speed the world up
        // Then slow the world down for 1 second
        CancelInvoke();
        Time.timeScale = 0.5f;
        Invoke("SpeedWorldUp", 1);
    }

    public void AdjustTime(float amount)
    {
        gameTime += amount;
        if (amount < 0)
        {
            SlowWorldDown();
        }
            
    }

    // Note this is using unity's legacy GUI system
    void OnGUI()
    {
        if (!isGameOver)
        {
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 50);
            GUI.Box(boxRect, "Time Remaining");

            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height - 80, 40, 80);
            GUI.Label(labelRect, ((Mathf.Round((float)gameTime * 10)/10).ToString()));
        }
        else
        {
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            GUI.Box(boxRect, "Game Over");

            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Time: " + (int)totalTimeElapsed);
            Time.timeScale = 0;
        }
    }

}
