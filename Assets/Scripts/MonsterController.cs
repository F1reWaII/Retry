using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player; // Transform of the player
    public float speed = 5f; // Speed of the monster
    private bool isChasing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            StartCoroutine(ChasePlayer());
        }
    }

IEnumerator ChasePlayer()
{
    while (isChasing && player!= null && rb!= null)
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(targetPosition + directionToPlayer * speed * Time.fixedDeltaTime);

        yield return null; // Wait for the next frame
    }
}



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
    
}
