using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EncounterManager : MonoBehaviour
{
    bool encounterStarted=false;
    public float leftBarrierPos, rightBarrierPos;
    GameObject leftBarrier, rightBarrier;

    public int currentWave = 0;

    [System.Serializable]
    public struct wave
    {
        public enemy[] enemies;
    }
    [System.Serializable]
    public struct enemy
    {
        public Vector2 pos;
        public string name;
    }
    public wave[] waves;

    public Image fightIcon;

    List<GameObject> currentWaveEnemies=new List<GameObject>();
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!encounterStarted)
        {
            StartEncounter();
        }
    }

    void StartEncounter()
    {
        encounterStarted = true;

        leftBarrier = Instantiate(Resources.Load<GameObject>("EncounterBarrier"), new Vector2(leftBarrierPos, 0), Quaternion.identity);
        rightBarrier = Instantiate(Resources.Load<GameObject>("EncounterBarrier"), new Vector2(rightBarrierPos, 0), Quaternion.identity);
        leftBarrier.SetActive(true); 
        rightBarrier.SetActive(true);
        StartCoroutine(SpawnWaves());

        fightIcon.gameObject.SetActive(true);
        StartCoroutine(FightIconFadeOut());
    }

    void EndEncounter()
    {
        leftBarrier.SetActive(false);
        rightBarrier.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator SpawnWaves()
    {
        if (waves.Length <1)
        {
            yield break;
        }

        bool spawnNewWave = true;

        while (currentWave <= waves.Length)
        {
            yield return new WaitForSeconds(1f);

            spawnNewWave = true;

            foreach (GameObject e in currentWaveEnemies)
            {
                if (e != null)
                {
                    spawnNewWave = false;
                }
            }
            if (spawnNewWave)
            { 
                SpawnWave(currentWave);
                currentWave++;
            }
        }

        EndEncounter();
    }
    void SpawnWave(int waveNum)
    { 
        currentWaveEnemies.Clear();

        if (waveNum < 0 || waveNum > waves.Length-1)
        {
            return;
        }
        enemy[] w = waves[waveNum].enemies;
        foreach(enemy e in w)
        {
            GameObject newEnemy = Instantiate(Resources.Load<GameObject>("Enemies/" + e.name), e.pos, Quaternion.identity);
            currentWaveEnemies.Add(newEnemy);
        }
         
    }

    public IEnumerator FightIconFadeOut()
    {
        float newA = 255;

        while (fightIcon.color.a > 0)
        {
            newA -= 1f;

            fightIcon.color = new Color32(255,255,255, Convert.ToByte(newA));
            yield return new WaitForSeconds(0.005f);
        }
    }
}
