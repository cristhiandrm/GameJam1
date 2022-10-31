using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (gameManager.keys == 3 && gameManager.potions == 3)
            {
                gameManager.FinalGame();
            }
            else
            {
                gameManager.GameOver();
            }
        }
    }
}
