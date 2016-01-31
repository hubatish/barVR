using UnityEngine;
using System.Collections;

/// <summary>
/// Just spawn a bunch of items at start
/// </summary>
public class SpawnItems : MonoBehaviour {

    public Transform ingredient;

    public int numToSpawn = 7;

    public Vector3 spawnOffset = Vector3.up;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPos = transform.position + spawnOffset * (float)i;
            float randRange = 2f;
            spawnPos.x += UnityEngine.Random.Range(-randRange, randRange);
            spawnPos.z += UnityEngine.Random.Range(-randRange, randRange);
            Transform t = (Transform)GameObject.Instantiate(ingredient,spawnPos,Quaternion.identity);
            t.SetParent(transform);
        }
	}

    //TODO: Spawn more if none left?
}
