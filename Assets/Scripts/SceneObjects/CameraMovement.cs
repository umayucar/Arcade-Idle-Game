using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 cameraOffset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lastPosition = targetTransform.position + cameraOffset;

        transform.position = lastPosition;
    }
}
