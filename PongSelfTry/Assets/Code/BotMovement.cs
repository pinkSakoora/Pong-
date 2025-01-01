using UnityEngine;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 botMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.name == "Player1" && ball.transform.position.x < 1)
        {
            LeftBotControl();
        }
        else if (gameObject.name == "Player2" && ball.transform.position.x > -1)
        {
            RightBotControl();
        }
    }
    private void LeftBotControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                botMove = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                botMove = new Vector2(0, -1);
            }
            else
            {
                botMove = new Vector2(0, 0);
            }
    }
    private void RightBotControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            botMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            botMove = new Vector2(0, -1);
        }
        else
        {
            botMove = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        {
            rb.linearVelocity = botMove * moveSpeed;
        }
    }
}
