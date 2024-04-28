using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform target;
    public float smoooth;
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoooth);
        }
    }
}
