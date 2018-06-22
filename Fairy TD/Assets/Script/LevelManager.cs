using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance;

	public int wavesNumber = 3;
    public float gateStrength = 30f;

    public SimpleHealthBar healthBar;
    public Color mainColor;
    public Color secondColor;

    public CoinPanel coinPanel;
	public Text wavesText;

    public Camera mainCamera;

	private int currWave = 1;
    private int coins = 30;
    private float currStrength;

    public int Coins { get { return coins; } }
	public int Waves { get { return wavesNumber; } }
	public int CurrWave {
		get { return currWave; } 
		set { 
			currWave = value;
			//currWave = value%(wavesNumber+1); 
			if(currWave <= wavesNumber)
				UpdateWavesText ();
		} 
	}

	private void UpdateWavesText()
	{
		wavesText.text = (currWave).ToString ("00") + "/" + wavesNumber.ToString ("00");
	}

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        coinPanel.UpdateCoinPanel(coins);
        currStrength = gateStrength;
        healthBar.UpdateColor(mainColor);
        healthBar.UpdateBar(currStrength, gateStrength);
		UpdateWavesText ();
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
            healthBar.UpdateColor(secondColor);

        healthBar.UpdateBar(currStrength, gateStrength);
    }
}
