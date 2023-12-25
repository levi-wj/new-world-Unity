using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;

    private void Start(){
        LabelButtonWithCost();
    }

     private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText){
            Debug.LogError("Defender button has no cost text.");
        }
        else
        {
            costText.text = defenderPrefab.cost.ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<Selector>();
        //Set other defender button colors
        foreach(Selector button in buttons)
        {
            Text costText = button.GetComponentInChildren<Text>();
            button.SetChildrenColor(0, 0, 0, 255);
            costText.color = Color.white;
        }
        
        //Set selected defender button colors
        GetComponentInChildren<Text>().color = new Color32(19, 223, 236, 255);
        SetChildrenColor(255, 255, 255, 255);
        FindObjectOfType<Placement>().setSelectedDefender(defenderPrefab);
    }


    void SetChildrenColor(int r, int g, int b, int a)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
            {
                Transform currentObject = gameObject.transform.GetChild(i);
                SpriteRenderer sprite = currentObject.GetComponent<SpriteRenderer>();
                sprite.color = new Color(r, g, b, a);
            }
        }
    }
}
