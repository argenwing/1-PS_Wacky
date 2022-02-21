using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite spriteRed;
    [SerializeField]
    Sprite spriteCyan;

    PickupEffect effect;

    float freezeDuration;
    FreezerEffectActivated freezerActivated;
    float speedupDuration;
    float speedupFactor;
    SpeedupEffectActivated speedupActivated;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.PickupBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // determined sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = spriteCyan;
                freezeDuration = ConfigurationUtils.FreezerSeconds;
                freezerActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = spriteRed;
                speedupDuration = ConfigurationUtils.SpeedupSeconds;
                speedupFactor = ConfigurationUtils.SpeedupFactor;
                speedupActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupEffectInvoker(this);
            }
        }
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerActivated.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupActivated.AddListener(listener);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (effect == PickupEffect.Freezer)
            {
                AudioManager.Play(AudioClipName.FreezerEffectActivated);
                freezerActivated.Invoke(freezeDuration);
            }
            else if (effect == PickupEffect.Speedup)
            {
                AudioManager.Play(AudioClipName.SpeedupEffectActivated);
                speedupActivated.Invoke(speedupDuration, speedupFactor);
            }
            base.OnCollisionEnter2D(collision);
        }
    }
}
