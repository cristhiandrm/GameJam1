using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMov player;
    
    public Text timeToDead;
    public float countDown;
    private float startCountDown;

    public GameObject gameOverUI;
    public bool gameIsOver = false;
    public GameObject gameFinalUI;
    public GameObject WelcomeUI;

    public Text potiText;
    public Text keysText;
    public int potions = 0;
    public int keys = 0;

    public bool GameIsActive;

    private void Start()
    {
        startCountDown = countDown;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
        potiText.text = keys + "/3";
        keysText.text = keys + "/3";
        GameIsActive = false;
    }
    public void Update()
    {
        if (GameIsActive == true)
        {
            if (gameIsOver == true)
                return;

            if (Input.GetKeyDown("f"))
            {
                countDown = startCountDown;
            }
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                GameOver();
            }
            timeToDead.text = string.Format("{0:00:00}", countDown);

        }

        
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddKey()
    {
        keys++;
        keysText.text = keys+"/3";
    }

    public void Addpoti()
    {
        potions++;
        potiText.text = keys + "/3";
    }

    public void FinalGame()
    {
        gameIsOver = true;
        gameFinalUI.SetActive(true);
    }

    public void welcome()
    {
        GameIsActive = true;
        WelcomeUI.SetActive(false);
    }

}
