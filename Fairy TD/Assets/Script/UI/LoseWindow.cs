using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWindow : DialogWindow {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public override void Show(GameObject parent)
    //{
    //    DisplayWindow(parent);
    //}

    public override void PauseWorld()
    {
        Time.timeScale = 0;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().speed = 0;
            enemy.GetComponent<Animator>().enabled = false;
        }
           
    }
}
