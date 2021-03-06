using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitToSpawnPrefabs;

    public GameObject bombtoSpawnPrefab;
    public Transform[] spawnPlaces;

    private float minWait = 0.3f;

    private float maxWait = 1f;

    public float minForce = 10f;

    public float maxForce = 20f;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            var rand = Random.Range(0,100);

            if(rand <= 15){
                go = bombtoSpawnPrefab;
            }
            else{
                go = fruitToSpawnPrefabs[Random.Range(0, fruitToSpawnPrefabs.Length)];
            }

            GameObject fruit =
                Instantiate(go,
                t.transform.position,
                t.transform.rotation);

            fruit
                .GetComponent<Rigidbody2D>()
                .AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            

            Destroy(fruit, 5f);
        }
    }
}
