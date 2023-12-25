using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    [SerializeField] Transform parent;

    private Spawner myLaneSpawner;
    private Animator myAnimator;
    private float lane;

    public void Start()
    {
        lane = transform.position.y;
        myAnimator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (CheckAttackerInLane())
        {
            myAnimator.SetBool("Shooting", true);
        }
        else
        {
            myAnimator.SetBool("Shooting", false);
        }
    }

    public void Fire()
    {
        Instantiate(projectile, parent);
        return;
    }

    private void SetLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - lane) <= Mathf.Epsilon);
            if(isCloseEnough) { myLaneSpawner = spawner; }
        }
    }

    private bool CheckAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
