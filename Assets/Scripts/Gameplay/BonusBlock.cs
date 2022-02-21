using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    [SerializeField]
    Sprite spriteOrange;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        points = ConfigurationUtils.BonusBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOrange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
