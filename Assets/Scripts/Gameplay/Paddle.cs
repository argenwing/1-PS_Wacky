using UnityEngine;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// Scripts for paddle
    /// </summary>

    Rigidbody2D rgbd2d;
    float paddleHalfWidthCollider;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    Timer freezeTimer;
    bool frozen;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2D = GetComponent<BoxCollider2D>();
        paddleHalfWidthCollider = bc2D.size.x * transform.localScale.x / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(HandleFreezeTimerFinished);
        EventManager.AddFreezerEffectListener(HandleFreezerActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // move for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!frozen && horizontalInput != 0)
        {
            Vector2 position = rgbd2d.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.x = CalculateClampedX(position);
            rgbd2d.MovePosition(position);
        }
    }

    float CalculateClampedX (Vector2 position)
    {
        if (position.x - paddleHalfWidthCollider < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + paddleHalfWidthCollider;
        } else if (position.x + paddleHalfWidthCollider > ScreenUtils.ScreenRight) 
        {
            position.x = ScreenUtils.ScreenRight - paddleHalfWidthCollider;
        }
        return position.x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && TopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleHalfWidthCollider;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Check for a collision on top of the paddle
    /// </summary>
    /// <param name="coll"></param>
    /// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezerActivatedEvent(float duration)
    {
        frozen = true;
        if (!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }

    void HandleFreezeTimerFinished()
    {
        
        frozen = false;
        AudioManager.Play(AudioClipName.FreezerEffectDeactivated);
        freezeTimer.Stop();
    }
}

