using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatewCamera : MonoBehaviour
{

public Transform cameraTransform;
    // Update is called once per frame
    void Update()
    {
            cameraTransform.transform.rotation = gameObject.transform.rotation;
    }
}
