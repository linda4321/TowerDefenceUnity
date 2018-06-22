using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlace : MonoBehaviour {

    public static SpawnPlace Instance;

    public Text wavesText;

    public GameObject path;
    public int wavesNumber = 3;
    public float step = 2f;
    public float waveInterval = 5f;
   // public int monsterNumber = 1;
    public float interval = 1f;
  
    public GameObject[] monsterPrefabs;

    private float timer = 0f;
	private float monsterNumber = 3;
    private int waveSpawnedNumber = 0;

	private float waveTimer;
    private Transform[] pathPoints;

    private int currWave = 1;
    private int generalSpawnNumber = 0;
    private int currSpawnNumber = 0;

    private bool allEnemiesSpawned = false;

    public int Waves { get { return wavesNumber; } }
    public int AllEnemies { get { return generalSpawnNumber; } }

    public int CurrWave
    {
        get { return currWave; }
        set
        {
            currWave = value;
            //currWave = value%(wavesNumber+1); 
            if (currWave <= wavesNumber)
                UpdateWavesText();
        }
    }

    public bool AllEnemiesSpawned
    {
        get
        {
            return allEnemiesSpawned;
        }
    }

    private void UpdateWavesText()
    {
        wavesText.text = (currWave).ToString("00") + "/" + wavesNumber.ToString("00");
    }


    // Use this for initialization
    void Start () {
        Instance = this;
        pathPoints = path.GetComponentsInChildren<Transform>();
        timer = interval;
		waveTimer = waveInterval;
        generalSpawnNumber = (int)(2 * monsterNumber + (wavesNumber - 1) * step) / 2 * wavesNumber;
        UpdateWavesText();

    }
	
	// Update is called once per frame
	void Update () {
        if(currSpawnNumber == generalSpawnNumber)
        {
            allEnemiesSpawned = true;
        }

		if (CurrWave <= Waves) 
		{
			
			if (waveSpawnedNumber < monsterNumber) {
				if (timer <= 0) {
					GenerateObject ();
					timer = interval;
				} else
					timer -= Time.deltaTime;       
			} else {
                currSpawnNumber += waveSpawnedNumber;
				if (waveTimer > 0)
					waveTimer -= Time.deltaTime;
				else {
					waveTimer = waveInterval;
					waveSpawnedNumber = 0;
					CurrWave++;
					monsterNumber += step;
				}
			}
		}
        
	}



    private void GenerateObject()
    {
        int index = UnityEngine.Random.Range(0, monsterPrefabs.Length);
        GameObject obj = GameObject.Instantiate(monsterPrefabs[index], transform.position, transform.rotation) as GameObject;
        obj.GetComponent<Enemy>().Launch(pathPoints);
  //      Debug.Log(obj.tag);
        waveSpawnedNumber++;
        
    }

    IEnumerator WaitForNewMonster()
    {
        yield return new WaitForSeconds(interval);
    }
}
