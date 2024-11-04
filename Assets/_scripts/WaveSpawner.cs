using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveAmount = 0;
    private float waveGap = 0.5f;

    public TextMeshProUGUI waveCountdownText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveAmount++;
        for (int i = 0; i < waveAmount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waveGap);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
