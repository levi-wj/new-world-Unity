using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int health;

    public void dealDamage(int damage)
    {
        health -= damage;
        if(health < 1)
        {
            Animator myAnimator = gameObject.GetComponent<Animator>();
            if (GetComponent<Attacker>())
            {
                gameObject.transform.SetParent(null);
                myAnimator.SetTrigger("Death");
            }
            else
            {
                FindObjectOfType<Placement>().RemoveDefenderPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
                Destroy(gameObject);
            }
            
        }
    }
}
