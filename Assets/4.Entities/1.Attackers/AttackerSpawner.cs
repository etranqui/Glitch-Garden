using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;
    static int nbLanes;
    static float lastSpawnTime;

	// Use this for initialization
	void Start () {
        // Keep track of the number of lanes. This is to adjust the Attacker spawn rate
        nbLanes++;
	}
	
	// Update is called once per frame
	void Update () {
		
        // Loop through each attacker prefabs and spawn them
        foreach(GameObject attacker in attackerPrefabs)
        {
            if (isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }

	}

    // Spawn Attacker
    GameObject Spawn (GameObject go)
    {
        // Keep track of last spawn time and instantiate Attacker
        lastSpawnTime = Time.time;
        return Instantiate(go, transform.position, Quaternion.identity, gameObject.transform);
    }

    
    bool isTimeToSpawn(GameObject go)
    {
        // If last spawn was less that a second ago, exit
        if (Time.time - lastSpawnTime < 1)
            return false;

        Attacker attacker = go.GetComponent<Attacker>();
        float spawnPerSecond = 1 / attacker.spawnRate;
        float threshold = spawnPerSecond * Time.deltaTime / nbLanes;

        return (Random.value < threshold);        
    }

    private void OnDestroy()
    {
        // Keep track of the numbers of lane
        nbLanes--;
    }
}
