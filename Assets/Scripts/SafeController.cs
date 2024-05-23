using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject door;
    public Vector3 openPosition; // Позиция открытой двери
    public Vector3 closedPosition; // Позиция закрытой двери

    // Start is called before the first frame update
    void Start()
    {
        // Установите начальное положение двери на закрытое
        door.transform.position = closedPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
            // Изменяем позицию двери на открытую
            door.transform.position = openPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            // Изменяем позицию двери обратно на закрытую
            door.transform.position = closedPosition;
        }  
    }
}
