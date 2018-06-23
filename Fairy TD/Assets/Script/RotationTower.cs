using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTower : Tower {

    public GameObject topBase;

    private float rotationSpeed = 6f;
    private Vector3 startRot;

    void Start()
    {
        base.Start();
        startRot = transform.rotation.eulerAngles;
    }


    void Update()
    {
        base.Update();
        if(target == null)
        {
            topBase.transform.eulerAngles = Vector3.Lerp(topBase.transform.rotation.eulerAngles, startRot, Time.deltaTime);
        }
    }

    protected override void RotateToTarget(Vector3 target)
    {
        Vector3 targetDir = target - topBase.transform.position;
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(topBase.transform.forward, targetDir, step, 0.0f);
        topBase.transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
    }
}
