using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public string target = "Player";
    public bool objectDetected;

    public List<Collider2D> detectedObject = new List<Collider2D>();

    public void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == target)
        {
            
            //detectedObject.Add(coll);
            objectDetected = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            //detectedObject.Remove(collision);
            objectDetected = false;
        }
    }

}
