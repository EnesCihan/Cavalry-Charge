using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    [SerializeField]
    private float lerpTime;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position + offset, lerpTime*Time.deltaTime);
        transform.position = newPos;
    }
}
