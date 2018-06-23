using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerField : MonoBehaviour
{

	public AudioClip sound;

    private bool hasTower = false;

	private AudioSource source;

	void Start()
	{
		source = gameObject.AddComponent<AudioSource>();
		source.clip = sound;
	}

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !hasTower)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                try
                {
                GameObject tower = GameObject.Instantiate(TowerManager.Instance.PressedButton.TowerObject);
                	if (tower != null)
                	{
						source.Play();
                	    buildTower(tower);
                 	   	hasTower = true;
                  	  	TowerManager.Instance.towerSet();
                   	 	TowerManager.Instance.TowersSpawned++;
                	}
                }
                catch
                {
                	
                }
            }
        }
    }

    void OnMouseOver()
    {
        if (!hasTower)
        {
            Color color = Color.yellow;
            gameObject.GetComponent<Renderer>().material.color = color;
        }

    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    private void buildTower(GameObject tower)
    {
        Transform trans = this.transform;
        Vector3 size = tower.GetComponentInChildren<Renderer>().bounds.size;
        float y = trans.position.y + size.y / 2;
        if (tower.tag == "WoodenTower")
            y -= size.y / 7;
        tower.gameObject.transform.eulerAngles = new Vector3(
                tower.transform.eulerAngles.x,
                trans.rotation.eulerAngles.y,
                tower.transform.eulerAngles.z);
        tower.transform.position = new Vector3(trans.position.x, y, trans.position.z);
        LevelManager.Instance.RemoveCoins(tower.GetComponent<Tower>().Price);
    }
}
