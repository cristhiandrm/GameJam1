using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 1f;
    public float timeToDestroy = 5f;
    private float timeDes = 0f;

    void Update()
    {
        timeDes += Time.deltaTime;
        transform.position += speed * transform.right * Time.deltaTime;
        if (timeToDestroy <= timeDes)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
