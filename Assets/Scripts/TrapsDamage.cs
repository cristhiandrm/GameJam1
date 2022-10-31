using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDamage : MonoBehaviour
{
    public PlayerMov player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            player.damage();
        }
    }
}
