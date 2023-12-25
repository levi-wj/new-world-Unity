using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {

    private bool jumping = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jumpables")
        {
            GetComponent<Animator>().SetTrigger("Jump");
            jumping = true;
        }

        if (jumping) { return; }
        if (collision.GetComponent<Defender>())
        {   
            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }

    public void stopJump()
    {
        jumping = false;
    }
}
