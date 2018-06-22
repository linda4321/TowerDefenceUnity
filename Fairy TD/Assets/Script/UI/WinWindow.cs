using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : DialogWindow {

    public Text coins;
    public Text life;
    public Text enemies;
//    public Text allEnemies;
    public Text towers;


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

    protected override void SetUpWindow()
    {
        coins.text = LevelManager.Instance.Coins.ToString("0000");
        life.text = LevelManager.Instance.CurrStrength.ToString("000") + "/" + LevelManager.Instance.MaxStrength.ToString("000");
        enemies.text = LevelManager.Instance.KilledEnemies.ToString("00") + "/" + SpawnPlace.Instance.AllEnemies.ToString("00");
        towers.text = TowerManager.Instance.TowersSpawned.ToString("00");
    }
}
