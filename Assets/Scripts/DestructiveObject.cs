using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }
}
