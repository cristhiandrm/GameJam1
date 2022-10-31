using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPlayer : MonoBehaviour
{
    private Vector2 moveInput;

    private Light2D luzJugador;

    private void Start()
    {
        luzJugador = GetComponent<Light2D>();
        luzJugador.color = Color.black;
    }


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);

            //if(transform.rotation.z >= 0)
            //{
            //    transform.Rotate(0.0f, 0.0f, 10.0f, Space.Self);
            //}

            luzJugador.color = Color.white;
        }
        else
        {
            if (moveX == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                luzJugador.color = Color.white;
            }

        }

        if (moveY == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            luzJugador.color = Color.white;
        }
        else
        {
            if (moveY == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -180);
                luzJugador.color = Color.white;
            }

        }





        //if (moveX == 0 && moveY == 0)
        //{
        //    luzJugador.color = Color.black;
        //}

    }

    private void LateUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 1 && moveY == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
            luzJugador.color = Color.white;
        }

        if (moveX == 1 && moveY == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -135);
            luzJugador.color = Color.white;
        }

        if (moveX == -1 && moveY == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            luzJugador.color = Color.white;
        }

        if (moveX == -1 && moveY == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            luzJugador.color = Color.white;
        }
    }
}
