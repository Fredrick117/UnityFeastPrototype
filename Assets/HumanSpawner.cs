using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public GameObject humanPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Initially spawn 10-25 humans
        for (int i = 0; i < Random.Range(10, 25); i++) {
            Instantiate(humanPrefab, new Vector3(Random.Range(-50, 50), 2, Random.Range(-70, 70)), transform.rotation);
        }

        // Spawn a human every second afterwards
        StartCoroutine("SpawnHuman");
    }

    IEnumerator SpawnHuman() {
        for (; ; ) {
            Instantiate(humanPrefab, new Vector3(Random.Range(-50, 50), 2, Random.Range(-70, 70)), transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
