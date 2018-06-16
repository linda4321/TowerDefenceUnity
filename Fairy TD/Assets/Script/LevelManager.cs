using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance;

    public CoinPanel coinPanel;


    private int coins = 5;

    public int Coins { get { return coins; } }

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        coinPanel.UpdateCoinPanel(coins);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoins(int coins)
    {
        this.coins += coins;
        coinPanel.UpdateCoinPanel(this.coins);
    }

    public void RemoveCoins(int coins)
    {
        if (this.coins >= coins)
            this.coins -= coins;
        coinPanel.UpdateCoinPanel(this.coins);
    }

}
