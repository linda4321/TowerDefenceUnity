using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance;

    public float gateStrength = 30f;
    public SimpleHealthBar healthBar;
    public CoinPanel coinPanel;

    public Camera mainCamera;


    private int coins = 5;
    private float currStrength;

    public int Coins { get { return coins; } }

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        coinPanel.UpdateCoinPanel(coins);
        currStrength = gateStrength;
        healthBar.UpdateBar(currStrength, gateStrength);
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

    public void DamageGate(float damage)
    {
        currStrength -= damage;

        if (currStrength <= gateStrength / 4)
            healthBar.UpdateColor(new Color(141, 27, 34));

        healthBar.UpdateBar(currStrength, gateStrength);
    }
}
