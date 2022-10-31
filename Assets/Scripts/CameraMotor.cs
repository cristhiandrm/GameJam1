using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookat;
    public float boundx = 0.15f;
    public float boundy = 0.05f;

    private void Start()
    {
        lookat = GameObject.Find("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltax = lookat.position.x - transform.position.x;
        if (deltax > boundx || deltax < -boundx)
        {
            if (transform.position.x < lookat.position.x)
            {
                delta.x = deltax - boundx;
            }
            else
            {
                delta.x = deltax + boundx;
            }
        }
        float deltay = lookat.position.y - transform.position.y;
        if (deltay > boundy || deltay < -boundy)
        {
            if (transform.position.y < lookat.position.y)
            {
                delta.y = deltay - boundy;
            }
            else
            {
                delta.y = deltay + boundy;
            }
        }
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
