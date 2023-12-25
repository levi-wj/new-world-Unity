using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (0f, 5f)]
    [SerializeField] float walkSpeed = 1f;

    GameObject currentTarget;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        FindObjectOfType<LevelController>().attackersAlive += 1;
    }

    void Update ()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimationState();
	}

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            myAnimator.SetBool("Attacking", false);
        }
    }

    public void Die()
    {
        FindObjectOfType<LevelController>().attackersAlive -= 1;
        Destroy(gameObject);
    }

    public void setSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        myAnimator.SetBool("Attacking", true);
        currentTarget = target;
    }

    public void DealDamage(int damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.dealDamage(damage);
        }
    }
}
