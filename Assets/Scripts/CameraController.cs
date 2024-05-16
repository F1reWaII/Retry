using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera;
    public Transform CameraPosition; // Изменено тип с GameObject на Transform
    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 targetPosition = CameraPosition.position;
        Vector3 newPosition = Vector3.Lerp(Camera.transform.position, targetPosition, smoothSpeed);
          
        Camera.transform.position = newPosition;
        velocity = (newPosition - Camera.transform.position).normalized * smoothSpeed;
    }
}
