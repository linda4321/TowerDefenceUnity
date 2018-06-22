using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlace : MonoBehaviour {

    public GameObject path;
	public float waveInterval = 5f;
   // public int monsterNumber = 1;
    public float interval = 1f;

    public GameObject[] monsterPrefabs;

    private float timer = 0f;
	private float monsterNumber = 3;
    private int spawnedNumber = 0;

	private float waveTimer;
    private Transform[] pathPoints;

    // Use this for initialization
    void Start () {
        pathPoints = path.GetComponentsInChildren<Transform>();
        timer = interval;
		waveTimer = waveInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelManager.Instance.CurrWave <= LevelManager.Instance.Waves) 
		{
			
			if (spawnedNumber < Math.Floor(monsterNumber)) {
				if (timer <= 0) {
					GenerateObject ();
					timer = interval;
				} else
					timer -= Time.deltaTime;       
			} else {
				if (waveTimer > 0)
					waveTimer -= Time.deltaTime;
				else {
					waveTimer = waveInterval;
					spawnedNumber = 0;
					LevelManager.Instance.CurrWave++;
					monsterNumber += 1.5f;
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
        spawnedNumber++;
        
    }

    IEnumerator WaitForNewMonster()
    {
        yield return new WaitForSeconds(interval);
    }
}
