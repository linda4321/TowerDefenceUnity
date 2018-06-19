using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {

    [SerializeField]
    private GameObject towerObject;
    [SerializeField]
    private GameObject towerObjectMini;

    [SerializeField]
    private Text price;

    private Button button;
    private Tower tower;

    void Awake()
    {
        button = GetComponent<Button>();
        tower = towerObject.GetComponent<Tower>();
    }

    void Start()
    {
       // price.text = tower.Price.ToString("00");
    }

    void Update()
    {
        if(LevelManager.Instance.Coins >= tower.Price)
        {
            if (!button.enabled)
                button.enabled = true;
        }
        else
        {
            if (button.enabled)
                button.enabled = false;
        }
    }

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }

    public GameObject TowerObjectMini
    {
        get
        {
            return towerObjectMini;
        }
    }
    

}
