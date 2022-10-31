using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] AudioClip soundPickUp;
    public GameManager gameManager;
    public bool itsKey;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (itsKey)
            {
                gameManager.AddKey();
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(soundPickUp, transform.position);
            }
            else
            {
                gameManager.Addpoti();
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(soundPickUp, transform.position);
            }
            
        }

    }
}
