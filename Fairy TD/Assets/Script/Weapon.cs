using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Vector3 target;
    public float pauseToDisappear = 2f;
    public float strength = 5f;

    public float speed = 1f;

    private bool isGrounded;
    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        //      Vector3 targetDir = target.transform.position - transform.position;
        //        float step = 1 * Time.deltaTime;
        //       Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //       Debug.DrawRay(transform.position, newDir, Color.red);
        //       transform.rotation = Quaternion.LookRotation(newDir);
        //     Vector3 targetDir = target.transform.position - transform.position;
        // The step size is equal to speed times frame time.
        //     float step = 2 * Time.deltaTime;
        //     transform.position = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        if (!isGrounded)
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        // transform.rotation = Quaternion.LookRotation(newDir);
    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            DestroyOnGroundCollision();
        }
        else if (col.gameObject.tag == "Enemy" && !isGrounded)
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            Debug.Log("Collision");
            enemy.GetDamage(strength);
            DestroyOnEnemyCollision();
        }

        OnCollision();
    }

    protected virtual void DestroyOnGroundCollision()
    {
        Destroy(this.gameObject, pauseToDisappear);
    }

    protected virtual void DestroyOnEnemyCollision()
    {

        Destroy(this.gameObject);
    }

    protected virtual void OnCollision()
    {
    }

}
