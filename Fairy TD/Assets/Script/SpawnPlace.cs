using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlace : MonoBehaviour {

    public GameObject path;
    public int monsterNumber = 1;
    public float interval = 1f;

    public GameObject[] monsterPrefabs;

    private float timer = 0f;
    private int spawnedNumber = 0;

    private Transform[] pathPoints;

    // Use this for initialization
    void Start () {
        pathPoints = path.GetComponentsInChildren<Transform>();
        timer = interval;
        Debug.Log("Pos " + transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if(spawnedNumber < monsterNumber)
        {
            if (timer <= 0)
            {
                GenerateObject();
                timer = interval;
            }
            else
                timer -= Time.deltaTime;       
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
