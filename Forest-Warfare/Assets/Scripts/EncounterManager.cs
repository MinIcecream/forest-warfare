using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EncounterManager : MonoBehaviour
{
    bool encounterStarted=false;
    public float leftBarrierPos, rightBarrierPos;
    GameObject leftBarrier, rightBarrier;

    public int currentWave = 0; 

    [System.Serializable]
    public struct wave
    {
        public List<enemy> enemies;
    }
    [System.Serializable]
    public struct enemy
    {
        public Vector2 pos;
        public string name;
    }
    public List <wave> waves=new List<wave>();

    public Image fightIcon;
    public Image contArrow;

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

    public void EndEncounter()
    { 
        rightBarrier.SetActive(false);
        contArrow.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void StartEndEncounter()
    {
        rightBarrier.GetComponent<EncounterBarrier>().SetEndEncounterBarrier(this);

        leftBarrier.SetActive(false);
        contArrow.gameObject.SetActive(true); 
    }

    public IEnumerator SpawnWaves()
    {
        if (waves.Count <1)
        {
            yield break;
        }

        bool spawnNewWave = true;

        while (currentWave <= waves.Count)
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

        StartEndEncounter();
    }
    void SpawnWave(int waveNum)
    { 
        currentWaveEnemies.Clear();

        if (waveNum < 0 || waveNum > waves.Count-1)
        {
            return;
        } 
        List<enemy> w = waves[waveNum].enemies;
        foreach (enemy e in w)
        {
            if (e.name!=""){ 
                GameObject newEnemy = Instantiate(Resources.Load<GameObject>("Enemies/" + e.name), e.pos, Quaternion.identity);
                currentWaveEnemies.Add(newEnemy);
            } 
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

#if UNITY_EDITOR
    public GameObject[] enemiesToSave;
    public int waveToSave;

    public void SaveLevel()
    {  
        waves[waveToSave].enemies.Clear();

        foreach(GameObject e in enemiesToSave)
        {
            enemy newEnemy = new enemy();
            newEnemy.pos.x=e.transform.position.x;
            newEnemy.pos.y=e.transform.position.y;
            newEnemy.name=e.name;

            waves[waveToSave].enemies.Add(newEnemy);
        }
    }
}

[CustomEditor(typeof(EncounterManager))]
public class EncounterManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EncounterManager creator = (EncounterManager)target;
        if (GUILayout.Button("Save Level"))
        {
            creator.SaveLevel();
        }
    }
#endif
}
