using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveSpawner2 : MonoBehaviour
{

    public Transform enemies; //the Enemy prefeb goes here
    public Transform enemySpawnPoint;

    public float timeInBetweenWaves = 5f;
    private float countdown = 5f;
    public Text waveCountdownText;
      
    private int waveIndex = 0;
    private int waveIncrease = 5;
    private int waveMaths;

    private void Start()
    {
        //InvokeRepeating("EnemySpawner", timer, timerIncrease);
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnEachWave());
            SpawnEachWave();
            countdown = timeInBetweenWaves;
            timeInBetweenWaves += 5; //Increase the time before each wave hits
        }
        countdown -= Time.deltaTime; //Reduces with time and when hits 0, resets time to 5 seconds.
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnEachWave() //Allows me to essentially pause the code for a brief amount of time.
    {
        WaveMaths();
        for (int i = 0; i < waveIndex; i++)
        {
            EnemySpawner();
            //WaveMaths();
            yield return new WaitForSeconds(0.25f/*timerMaths*/); //The time between waves increase by seconds every ten seconds
        }
            }


    void EnemySpawner()
    {
        Instantiate(enemies, enemySpawnPoint.position, enemySpawnPoint.rotation); //Will spawn enemies at declared position on map.
        
    }

    void WaveMaths()
    {
        waveIndex += waveIncrease; //Incremental increase of enemies per wave.
        //waveMaths = waveIndex + waveIncrease; //This kinda worked, but I dont think this worked properly so I reattempted this.
    }

}
