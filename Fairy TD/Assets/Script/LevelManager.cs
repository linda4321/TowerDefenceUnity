using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public float gateStrength = 30f;

    public SimpleHealthBar healthBar;
    public Color mainColor;
    public Color secondColor;

    public CoinPanel coinPanel;

    public Camera mainCamera;

    public WinWindow winWindow;
    public LoseWindow loseWindow;

    private int killedEnemies;

    private int coins = 30;
    private float currStrength;
    private GameObject canvas;

    public int Coins { get { return coins; } }
    public float MaxStrength { get { return gateStrength; } }
    public float CurrStrength { get { return currStrength; } }

    public int KilledEnemies
    {
        get { return killedEnemies; }
        set { killedEnemies = value; }
    }

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("LM created");
        coinPanel.UpdateCoinPanel(coins);
        currStrength = gateStrength;
        healthBar.UpdateColor(mainColor);
        healthBar.UpdateBar(currStrength, gateStrength);
        canvas = GameObject.FindWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (currStrength <= 0)
            OnPlayerLose();

        if (currStrength > 0 && SpawnPlace.Instance.AllEnemiesSpawned && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            OnPlayerWin();
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

    private void OnPlayerLose()
    {
        loseWindow.Show(canvas);
        Destroy(this.gameObject);
        
    }

    private void OnPlayerWin()
    {
        winWindow.Show(canvas);
        Destroy(this.gameObject);
    }
}
