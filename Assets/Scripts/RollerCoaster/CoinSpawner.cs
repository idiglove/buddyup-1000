using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        // float spawnTime1 = Random.Range(0.3f, 1f);
        // InvokeRepeating("SpawnTrack1Coin", spawnTime1, 2f);
        // InvokeRepeating("SpawnTrack2Coin", 1f, 3f);
        // InvokeRepeating("SpawnTrack3Coin", 1f, 3.5f);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while (true) {
            float spawnTime1 = Random.Range(0.5f, 2f);
            float spawnTime2 = Random.Range(1f, 2f);
            float spawnTime3 = Random.Range(1.5f, 2f);

            // float spawnObsTime1 = Random.Range(2.1f, 3f);
            // float spawnObsTime2 = Random.Range(3f, 4f);
            // float spawnObsTime3 = Random.Range(4f, 5f);

            int random1 = Random.Range(0,1);
            int random2 = Random.Range(0,1);
            int random3 = Random.Range(0,1);

            Invoke(Random.value < 0.5 ? "SpawnTrack1Coin" : "SpawnTrack1Obstacle", spawnTime1);
            Invoke(Random.value < 0.5 ? "SpawnTrack2Coin" : "SpawnTrack2Obstacle", spawnTime2);
            Invoke(Random.value < 0.5 ? "SpawnTrack3Coin" : "SpawnTrack3Obstacle", spawnTime3);

            // Invoke("SpawnTrack1Obstacle", spawnObsTime1);
            // Invoke("SpawnTrack2Obstacle", spawnObsTime2);
            // Invoke("SpawnTrack3Obstacle", spawnObsTime3);
            
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnTrack1Coin () {
        objectPooler.SpawnFromPool("Coin1", new Vector3(-10f, 2.2f));
    }

    void SpawnTrack2Coin () {
        objectPooler.SpawnFromPool("Coin1", new Vector3(-10f, 0.03f));
    }

    void SpawnTrack3Coin () {
        objectPooler.SpawnFromPool("Coin1", new Vector3(-10f, -2.1f));
    }

    void SpawnTrack1Obstacle () {
        objectPooler.SpawnFromPool("Obstacle", new Vector3(-10f, 2.2f));
    }

    void SpawnTrack2Obstacle () {
        objectPooler.SpawnFromPool("Obstacle", new Vector3(-10f, 0.03f));
    }

    void SpawnTrack3Obstacle () {
        objectPooler.SpawnFromPool("Obstacle", new Vector3(-10f, -2.1f));
    }

    private void FixedUpdate() {
        // objectPooler.SpawnFromPool("Track1Coin", new Vector3(-10f, 2.2f));
    }
}
