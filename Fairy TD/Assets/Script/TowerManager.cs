using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public static TowerManager Instance;

    private TowerButton pressed;
    private bool isPressed = false;
    private GameObject towerToMove;


    private int towersSpawned = 0;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(isPressed && pressed != null)
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = 10f;
            Vector3 trans = Camera.main.ScreenToWorldPoint(mouse);
            Vector3 size = towerToMove.GetComponent<Renderer>().bounds.size;
            float y = trans.y + size.y / 2;
            if (towerToMove.tag == "WoodenTower")
                y -= size.y / 7;
            towerToMove.transform.position = new Vector3(trans.x, y, trans.z);
        }
	}

    public void selectedTower(TowerButton selected)
    {
        if (towerToMove != null)
            Destroy(towerToMove);
        if(pressed == null || pressed.tag != selected.tag)
        {
            pressed = selected;
            towerToMove = GameObject.Instantiate(pressed.TowerObjectMini);
            towerToMove.gameObject.transform.eulerAngles = new Vector3(
                towerToMove.transform.eulerAngles.x,
                towerToMove.transform.eulerAngles.y,
                towerToMove.transform.eulerAngles.z);
			Vector3 scale = towerToMove.gameObject.transform.localScale;
			float factor = 100f;
			scale /= factor;
			towerToMove.gameObject.transform.localScale = scale;
            isPressed = true;
        }
        else
        {
            isPressed = false;
            pressed = null;
        }
       
    }

    public TowerButton PressedButton
    {
        get
        {
            return pressed;
        }
    }

    public int TowersSpawned
    {
        get
        {
            return towersSpawned;
        }

        set
        {
            towersSpawned = value;
        }
    }

    public void towerSet()
    {
        isPressed = false;
        pressed = null;
        Destroy(towerToMove);
    }
}
