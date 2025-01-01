using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float moveSpeed;
    private readonly float speedIncrease = 0.25f;
    public TextMeshProUGUI p1Score, p2Score;
    public int p1, p2;

    private Rigidbody2D rb;
    private int hitcounter;

    public ParticleSystem wallImpact;
    public ParticleSystem playerImpact;
    public ParticleSystem scoreImpact;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(StartBall), 3f);
        rb.linearVelocity = new Vector2(0, 0);
        transform.position = Vector3.zero;
        hitcounter = 0;
        p1 = 0;
        p2 = 0;
    }

    void StartBall()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;
        float xVelocity = -1f;
        if (isRight)
        {
            xVelocity = 1f;
        }
        float yVelocity = UnityEngine.Random.Range(-1, 1);
        rb.linearVelocity = new Vector2(xVelocity * moveSpeed + hitcounter * speedIncrease, yVelocity * moveSpeed + hitcounter * speedIncrease);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, moveSpeed + hitcounter * speedIncrease);
    }

    void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
    void ResetBall()
    {
        rb.linearVelocity = new Vector2(0, 0);
        Invoke(nameof(ResetPosition),1.5f);
        hitcounter = 0;
        Invoke(nameof(StartBall), 3f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "LeftWall" || other.collider.name == "RightWall")
        {
            ResetBall();
            CreateScoreImpact();
            if (other.collider.name == "LeftWall" || other.collider.name == "RightWall")
            {
                if (other.collider.name == "LeftWall")
                {
                    p2++;
                    p2Score.text = p2.ToString();
                }

                if (other.collider.name == "RightWall")
                {
                    p1++;
                    p1Score.text = p1.ToString();
                }
            }
        }
        if (other.collider.name == "Player1" || other.collider.name == "Player2")
        {
            PlayerBounce(other.transform);
            CreatePlayerImpact();
        }
        if (other.collider.name == "BottomWall" || other.collider.name == "TopWall")
        {
            CreateWallImpact();
        }
    }

    private void PlayerBounce(Transform myObject)
    {
        hitcounter++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;
        float xDirection, yDirection;
        if (ballPos.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.linearVelocity = new Vector2(xDirection, yDirection) * (moveSpeed + hitcounter * speedIncrease);
    }

    private void CreateWallImpact()
    {
        wallImpact.Play();
        audioManager.PlaySFX(audioManager.hit);
    }

    private void CreatePlayerImpact()
    {
        playerImpact.Play();
        audioManager.PlaySFX(audioManager.hit);
    }
    private void CreateScoreImpact()
    {
        scoreImpact.Play();
        audioManager.PlaySFX(audioManager.score);
    }
}