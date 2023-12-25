using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] int speed = 5;
    [SerializeField] int damage = 1;

	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health targetHealth = other.GetComponent<Health>();
        Attacker attacker = other.GetComponent<Attacker>();

        if(attacker && targetHealth)
        {
            targetHealth.dealDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
}
