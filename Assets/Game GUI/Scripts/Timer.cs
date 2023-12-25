using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [Tooltip("Time it takes for the level to complete in seconds")]
    [SerializeField] float levelTime = 10;
    public bool isTimerFinished = false;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;

        isTimerFinished = (Time.timeSinceLevelLoad >= levelTime);
    }
}
