using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    public int attackersAlive = 0;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    private void Update()
    {
        if(attackersAlive == 0 && FindObjectOfType<Timer>().isTimerFinished)
        {
            Win();
        }
    }

    void Win(){
        winLabel.SetActive(true);
    }

    public void Lose(){
        loseLabel.SetActive(true);
    }
}
