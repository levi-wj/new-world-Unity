using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour {

    [SerializeField] public int stars = 40;

    private Text startText;

    private void Start()
    {
        startText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void changeStarsBy(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        startText.text = "stars: " + stars.ToString();
    }
}
