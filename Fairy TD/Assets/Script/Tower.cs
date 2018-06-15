using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject weapon;

    public Transform[] weaponSpawns;

    
    public float attackSpeed = 1f;

    public float attackRadius = 5f;
    public float attackInterval = 2f;

    private Transform weaponSpawnPoint;
    //   private Queue<Enemy> enemies;

    private Collider[] objectsInArea;

    protected Enemy target;

    private float attackTimer;
	// Use this for initialization
	void Start () {
        attackTimer = attackInterval;
    }
	
	// Update is called once per frame
	void Update () {
       
        if(target == null)
        {
            objectsInArea = Physics.OverlapSphere(transform.position, attackRadius);

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

    protected void FindTarget()
    {

    }

    private float DistanceToEnemy(Enemy target)
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void Attack()
    {
        ChangeWeaponSpawnPoint();
 //       Debug.Log("Attack: " + target.transform.position);
        GameObject obj = GameObject.Instantiate(this.weapon, weaponSpawnPoint.position, weapon.transform.rotation);
        Weapon weaponObj = obj.GetComponent<Weapon>();
        weaponObj.speed = attackSpeed;
        weaponObj.target = target.transform.position;
    }

    protected virtual void ChangeWeaponSpawnPoint()
    {
        Transform spawnPoint = weaponSpawns[0];
        float prevDist = Vector3.Distance(weaponSpawns[0].position, target.transform.position);
        float currDist = 0;

        for (int i = 1; i < weaponSpawns.Length; i++)
        {
            currDist = Vector3.Distance(weaponSpawns[i].position, target.transform.position);
            if (currDist < prevDist)
                spawnPoint = weaponSpawns[i];
            prevDist = currDist;
        }

        weaponSpawnPoint = spawnPoint;
    }
}
