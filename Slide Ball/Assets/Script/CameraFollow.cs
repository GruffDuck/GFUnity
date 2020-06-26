using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ [SerializeField]
    private Transform target;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Vector3 offset;
    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position,target.position+offset,Time.deltaTime*smooth);
    }
}
