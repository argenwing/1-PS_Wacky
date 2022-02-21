using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite spriteGreen;
    [SerializeField]
    Sprite spriteDarkGreen;
    [SerializeField]
    Sprite spriteGrey;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        points = ConfigurationUtils.StandardBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteRandomNumber = Random.Range(0,3);
        if (spriteRandomNumber == 0)
        {
            spriteRenderer.sprite = spriteGreen;
        } 
        else if (spriteRandomNumber == 1)
        {
            spriteRenderer.sprite = spriteDarkGreen;
        }
        else
        {
            spriteRenderer.sprite = spriteGrey;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
