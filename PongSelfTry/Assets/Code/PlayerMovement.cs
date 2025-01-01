using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.name == "Player2")
        {
            Player2Control();
        }
        else
        {
            Player1Control();
        }
    }
    private void Player1Control()
    {
        if (isAI)
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                playerMove = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                playerMove = new Vector2(0, -1);
            }
            else
            {
                playerMove = new Vector2(0, 0);
            }
        }
        else
        {
            playerMove = new Vector2(0, Input.GetAxis("Vertical1"));
        }

    }
    private void Player2Control()
    {
        if (isAI)
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                playerMove = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                playerMove = new Vector2(0, -1);
            }
            else
            {
                playerMove = new Vector2(0, 0);
            }
        }
        else
        {
            playerMove = new Vector2(0, Input.GetAxis("Vertical2"));
        }

    }
    private void FixedUpdate()
    {
        if (isAI)
        {
            rb.linearVelocity = playerMove * moveSpeed / 3;

        }
        else
        {
            rb.linearVelocity = playerMove * moveSpeed;
        }
    }
}
