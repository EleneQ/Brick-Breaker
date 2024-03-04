using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public event Action OnBallCollision;

    [SerializeField] float speed = 8f;
    [SerializeField] float randomAngleRange = 15f;

    private Rigidbody2D rb;
    private Vector2 direction;
    private bool isMoving = false;

    [SerializeField] Paddle paddle;
    Vector2 paddleToBallDistance;

    Vector3 lastVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleToBallDistance = transform.position - paddle.transform.position;
    }


    private void Update()
    {
        if (!isMoving)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void FixedUpdate()
    {
        #region Explanation
        //normalizing the ball's velocity to maintain a constant speed to prevent the ball from exceeding the maximum
        //speed when it bounces or moves
        #endregion
        rb.velocity = rb.velocity.normalized * speed;
        lastVelocity = rb.velocity;
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = paddle.transform.position;
        transform.position = paddlePos + paddleToBallDistance;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            rb.velocity = Vector2.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnBallCollision?.Invoke();

        Vector2 normal = collision.contacts[0].normal;
        #region Explanation
        //calculates the new direction of the ball after the collision using the normal of the collision, reflects
        //the lastVelocity of the ball over this normal to simulate a bounce
        #endregion
        direction = Vector2.Reflect(lastVelocity.normalized, normal); 

        float randomAngle = Random.Range(-randomAngleRange, randomAngleRange);
        direction = Quaternion.Euler(0f, 0f, randomAngle) * direction;

        #region Explanation
        //sets the ball's velocity to move in this new direction with the constant speed
        #endregion
        rb.velocity = direction * speed; 
    }
}
