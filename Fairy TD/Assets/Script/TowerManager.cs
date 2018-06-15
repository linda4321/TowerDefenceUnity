using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public static TowerManager current;

    private TowerButton pressed;
    private bool isPressed = false;
    private GameObject towerToMove;

	// Use this for initialization
	void Start () {
        current = this;
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
        pressed = selected;
        towerToMove = GameObject.Instantiate(pressed.TowerObjectMini);
        towerToMove.gameObject.transform.eulerAngles = new Vector3(
            towerToMove.transform.eulerAngles.x, 
            towerToMove.transform.eulerAngles.y, 
            towerToMove.transform.eulerAngles.z);
        if (towerToMove.tag == "WoodenTower")
            towerToMove.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
        else
            towerToMove.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        isPressed = true;
    }

    public TowerButton PressedButton
    {
        get
        {
            return pressed;
        }
    }

    public void towerSet()
    {
        isPressed = false;
        Destroy(towerToMove);
    }
}
