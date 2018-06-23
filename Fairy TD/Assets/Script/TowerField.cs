using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerField : MonoBehaviour
{

    public int sideToFace = 0;

    private bool hasTower = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !hasTower)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // try
                //  {
                GameObject tower = GameObject.Instantiate(TowerManager.Instance.PressedButton.TowerObject);
                if (tower != null)
                {
                    buildTower(tower);
                    hasTower = true;
                    TowerManager.Instance.towerSet();
                    TowerManager.Instance.TowersSpawned++;
                }
                //  }
                //   catch
                //   {
                //       Debug.Log("Choose tower!");
                //   }
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
    //    float angY = tower.transform.eulerAngles.y;
        //if (sideToFace == 1)
        //    angY -= 90;
        //else if (sideToFace == 2)
        //    angY -= 180;
        //else if (sideToFace == 3)
        //    angY += 90;
     //   tower.gameObject.transform.rotation = trans.rotation;
        tower.gameObject.transform.eulerAngles = new Vector3(
                tower.transform.eulerAngles.x,
                trans.rotation.eulerAngles.y,
                tower.transform.eulerAngles.z);
        tower.transform.position = new Vector3(trans.position.x, y, trans.position.z);
        LevelManager.Instance.RemoveCoins(tower.GetComponent<Tower>().Price);
    }
}
