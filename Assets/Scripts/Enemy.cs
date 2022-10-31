using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    public bool enLuz;

    private Vector3 posicionInicial;

    private void Start()
    {
        posicionInicial = transform.position;
    }


    void Update()
    {
        if (!enLuz)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = posicionInicial;
            }

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLight"))
        { enLuz = true; }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLight"))
        { enLuz = false; }
    }
}
