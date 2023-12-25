using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    [SerializeField] public int cost = 40;

    public void AddStars(int amount)
    {
        FindObjectOfType<Bank>().changeStarsBy(amount);
    }
}
