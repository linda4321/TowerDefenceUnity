using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject weapon;
    public Transform weaponSpawnPoint;
    public float attackSpeed = 1f;

    public float attackRadius = 5f;
    public float attackInterval = 2f;

 //   private Queue<Enemy> enemies;

    private Collider[] objectsInArea;

    private Enemy target;

    private float attackTimer = 0f;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        objectsInArea = Physics.OverlapSphere(transform.position, attackRadius);
        
        if(target == null)
        {
            foreach (Collider col in objectsInArea)
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    if (target == null)
                        target = enemy;
                    else if (DistanceToEnemy(enemy) < DistanceToEnemy(target))
                        target = enemy;
                }
            }
        }
        

        if(target != null)
        {
            if(attackTimer <= 0)
            {
                Attack();
                attackTimer = attackInterval;
            }           
            else
                attackTimer -= Time.deltaTime;

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
 //       Debug.Log("Attack: " + target.transform.position);
        GameObject obj = GameObject.Instantiate(this.weapon, weaponSpawnPoint.position, weapon.transform.rotation);
        Weapon weaponObj = obj.GetComponent<Weapon>();
        weaponObj.speed = attackSpeed;
        weaponObj.target = target.transform.position;
    }
}
