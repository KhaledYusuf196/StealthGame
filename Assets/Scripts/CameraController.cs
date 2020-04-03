using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform CameraTransform;
    Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        CameraTransform = Camera.main.transform;
        Offset = CameraTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraTransform.position = transform.position + Offset;
        CameraTransform.LookAt(transform.position);
    }
}
