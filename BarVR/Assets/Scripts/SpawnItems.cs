using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Just spawn a bunch of items at start
/// </summary>
public class SpawnItems : MonoBehaviour {

    public Transform ingredient;

    public int numToSpawn = 3;

    public Vector3 spawnOffset = Vector3.up;
    protected List<Transform> spawnedTransforms = new List<Transform>();

	// Use this for initialization
	void Start ()
    {
        SpawnPrefabs();
        StartCoroutine(CheckItems());
    }

    public void SpawnPrefabs()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPos = transform.position + spawnOffset * (float)i;
            float randRange = 2f;
            spawnPos.x += UnityEngine.Random.Range(-randRange, randRange);
            spawnPos.z += UnityEngine.Random.Range(-randRange, randRange);
            Transform t = (Transform)GameObject.Instantiate(ingredient, spawnPos, Quaternion.identity);
            t.SetParent(transform);
            spawnedTransforms.Add(t);
        }
    }

    //TODO: Spawn more if none left?
    protected IEnumerator CheckItems()
    {
        yield return new WaitForSeconds(2f);
        for(int i = spawnedTransforms.Count - 1; i >= 0; i--)
        {
            if (spawnedTransforms[i]==null)
            {
                spawnedTransforms.RemoveAt(i);
            }
            else if(!spawnedTransforms[i].gameObject.activeSelf)
            {
                spawnedTransforms.RemoveAt(i);
            }
            else if(spawnedTransforms[i].position.y<-30)
            {
                GameObject.Destroy(spawnedTransforms[i].gameObject);
                spawnedTransforms.RemoveAt(i);
            }
        }
        if (spawnedTransforms.Count == 0)
        {
            SpawnPrefabs();
        }
        StartCoroutine(CheckItems());
    }

}
