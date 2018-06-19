using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour {

 //   public Camera m_Camera;

    void Update()
    {
        transform.LookAt(transform.position + LevelManager.Instance.mainCamera.transform.rotation * Vector3.forward,
            LevelManager.Instance.mainCamera.transform.rotation * Vector3.up);
    }
}
