﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if(otherObject.GetComponent<Defender>() != null)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}