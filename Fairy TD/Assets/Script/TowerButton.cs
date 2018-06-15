using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour {

    [SerializeField]
    private GameObject towerObject;
    [SerializeField]
    private GameObject towerObjectMini;

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
