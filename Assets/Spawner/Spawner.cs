using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] Attacker[] spawnObjects;
    [SerializeField] int minSpawnDelay;
    [SerializeField] int maxSpawnDelay;
    [SerializeField] int initialDelay;

    private bool spawn = false;
    private float heat = 1;
	private float difficultyMultiplier;

	IEnumerator Start()
    {
        difficultyMultiplier = PlayerPrefsController.GetDifficulty() * 2 / 150;
        Timer timer = FindObjectOfType<Timer>();
        yield return new WaitForSeconds(initialDelay);
        spawn = true;

        while (spawn)
        {
            if(!timer.isTimerFinished)
            {
                SpawnAttacker();
                yield return new WaitForSeconds(Random.Range(minSpawnDelay / heat, maxSpawnDelay / heat));
            }
            else
            {
                spawn = false;
                StopAllCoroutines();
            }
        }
    }

    private void Update()
    {
        if (spawn)
        {
            //Make the game harder
            heat += difficultyMultiplier * Time.deltaTime;
        }
        
    }

    void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, spawnObjects.Length);
        Attacker newAttacker = Instantiate(spawnObjects[attackerIndex], gameObject.transform);

        newAttacker.transform.SetParent(transform, false);
    }

}
