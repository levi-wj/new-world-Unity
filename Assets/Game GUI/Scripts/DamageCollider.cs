using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    LevelController controller;

    private void Start()
    {
        controller = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        controller.Lose();
    }
}
