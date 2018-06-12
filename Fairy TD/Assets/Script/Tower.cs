using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject weapon;

    public float attackRadius = 5f;
    public float attackInterval = 2f;

 //   private Queue<Enemy> enemies;

    private Collider[] objectsInArea;

    private Enemy target;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
  //      enemies.Clear();
        objectsInArea = Physics.OverlapSphere(transform.position, attackRadius);
        
        foreach(Collider col in objectsInArea)
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            
            if (enemy != null)
            {               
                if (target == null)
                    target = enemy;
                else if(DistanceToEnemy(enemy) < DistanceToEnemy(target))
                    target = enemy;
            }
        }


        if(target != null)
        {
            Attack();

            if (DistanceToEnemy(target) > attackRadius || target.Dead)
                target = null;
        }
    }

    private float DistanceToEnemy(Enemy target)
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void Attack()
    {
        Debug.Log("Attack: " + target.transform.position);
    }
}
