using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    private Vector3 topBoundary;
    private Vector3 bottomBoundary;
    private bool movingUp = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        topBoundary = transform.position + new Vector3(0f, moveRange, 0f);
        bottomBoundary = transform.position - new Vector3(0f, moveRange, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= topBoundary.y)
            {
                // Reached the top boundary, switch direction
                movingUp = false;
                bottomBoundary = transform.position - new Vector3(0f, moveRange, 0f);
            }
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= bottomBoundary.y)
            {
                // Reached the bottom boundary, switch direction
                movingUp = true;
                topBoundary = transform.position + new Vector3(0f, moveRange, 0f);
            }
        }
    }

}
