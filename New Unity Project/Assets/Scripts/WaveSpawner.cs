using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text countdownText;

    public float timeBetweenWaves = 20f; // Twenty seconds

    private float countdown = 2f;
    private int waveIndex = 0;


	
	
	// Update is called once per frame
	void FixedUpdate () {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdownText.text = Mathf.Ceil(countdown).ToString();
	}

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds before spawning another enemy
                                                   // Spaces them out
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
