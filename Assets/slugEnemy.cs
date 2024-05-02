using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class slugEnemy : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float moveRange = 3f;
    private Vector3 leftBoundary;
    private Vector3 rightBoundary;
    private Rigidbody2D rb;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftBoundary = transform.position - new Vector3(moveRange, 0f, 0f);
        rightBoundary = transform.position + new Vector3(moveRange, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBoundary.x)
            {
                // Reached the right point, switch direction
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBoundary.x)
            {
                // Reached the left point, switch direction
                movingRight = true;
                Flip();
            }
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
