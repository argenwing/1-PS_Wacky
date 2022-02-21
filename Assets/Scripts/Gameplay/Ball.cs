using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A Ball
/// </summary>
public class Ball : MonoBehaviour
{

    // Start timer for balls life
    Timer deathTimer;
    BallDied ballDied;

    // Stop timer for balls
    Timer moveDelay;

    Timer haste;
    float speedupFactor;
    Rigidbody2D rb2D;

    ReduceBall reduceBall;

    // Start is called before the first frame update
    void Start()
    {
        moveDelay = gameObject.AddComponent<Timer>();
        moveDelay.Duration = 1;
        moveDelay.AddTimerFinishedListener(HandleMoveTimerFinished);
        moveDelay.Run();

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);
        deathTimer.Run();

        rb2D = GetComponent<Rigidbody2D>();
        haste = gameObject.AddComponent<Timer>();
        haste.AddTimerFinishedListener(HandleHasteTimerFinished);
        EventManager.AddSpeedupEffectListener(HandleSpeedupActivatedEvent);

        reduceBall = new ReduceBall();
        EventManager.AddReduceBallInvoker(this);

        ballDied = new BallDied();
        EventManager.AddBallDiedInvoker(this);

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void SetDirection (Vector2 direction)
    {
        Rigidbody2D rgbd2d = GetComponent<Rigidbody2D>();
        float speed = rgbd2d.velocity.magnitude;
        rgbd2d.velocity = speed * direction;
    }

    void StartMoving()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(ConfigurationUtils.BallImpluseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpluseForce * Mathf.Sin(angle));

        if (EffectUtils.SpeedupActive)
        {
            speedupFactor = EffectUtils.SpeedupFactor;
            haste.Duration = EffectUtils.SpeedupTimeLeft;
            haste.Run();
            force *= speedupFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    private void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            float ballHalfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - ballHalfColliderHeight < ScreenUtils.ScreenBottom)
            {
                AudioManager.Play(AudioClipName.BallLost);
                reduceBall.Invoke();
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block") ||
            collision.gameObject.CompareTag("Paddle") ||
            collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.Play(AudioClipName.BallCollision);
        }
    }

    public void AddReduceBallListener(UnityAction listener)
    {
        reduceBall.AddListener(listener);
    }

    public void AddBallDiedListener(UnityAction listener)
    {
        ballDied.AddListener(listener);
    }

    void HandleSpeedupActivatedEvent(float duration, float factor)
    {
        if (!haste.Running)
        {
            speedupFactor = factor;
            haste.Duration = duration;
            haste.Run();
            rb2D.velocity *= speedupFactor;
        }
        else
        {
            haste.AddTime(duration);
        }
    }

    void HandleMoveTimerFinished()
    {
        moveDelay.Stop();
        StartMoving();
    }

    void HandleDeathTimerFinished()
    {
        ballDied.Invoke();
        Destroy(gameObject);
    }

    void HandleHasteTimerFinished()
    {
        haste.Stop();
        rb2D.velocity *= 1 / speedupFactor;
    }
}
