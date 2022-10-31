using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public Transform posicion1;
    public Transform posicion2;
    public Transform posicion3;
    void Start()
    {
        Posicion();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Posicion();
        }
    }

    void Posicion()
    {
        int posicion = Random.Range(0, 3);
        switch (posicion)
        {
            case 0:
                transform.position = posicion1.position;
                break;
            case 1:
                transform.position = posicion2.position;
                break;
            case 2:
                transform.position = posicion3.position;
                break;
            default:
                transform.position = new Vector3(0, 0, 0);
                break;
        }


    }
}
