using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private GameObject gun;
    public GameObject player;
    void Start()
    {
        gun = GameObject.FindWithTag("gun");

        player = GameObject.FindGameObjectWithTag("player");

        player.GetComponent<playerController>().IKilledSomeone();
        transform.position = gun.transform.position;
    }

    void FixedUpdate()
    {
        if (this != null)
        {
            transform.Translate(0, .3f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            if(player != null)
            {
                player.GetComponent<playerController>().IKilledSomeone();
            }
            Destroy(this.gameObject);
        }
    }
}
