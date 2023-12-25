using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

    [SerializeField] Transform parent;

    private Defender defender;
    private Bank bank;
    private List<Vector2> takenPositions = new List<Vector2>();

    public void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void setSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return worldPos;
    }

    private void SpawnDefender(Vector2 pos)
    {
        if(defender == null) { return; }
        Vector2 snappedPos = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));

        if(!takenPositions.Contains(snappedPos))
        {
            if (defender.cost <= bank.stars)
            {
                takenPositions.Add(snappedPos);
                bank.changeStarsBy(defender.cost * -1);
                Instantiate(defender, snappedPos, transform.rotation, parent);
            }
        }
    }

    public void RemoveDefenderPosition(Vector2 position)
    {
        takenPositions.Remove(position);
    }
}
