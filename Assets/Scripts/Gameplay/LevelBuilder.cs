using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    GameObject prefabPickupBlock;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabPaddle);

        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x * tempBlock.transform.localScale.x;
        float blockHeight = collider.size.y * tempBlock.transform.localScale.x;
        Destroy(tempBlock);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float blockPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blockPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft + (screenWidth - totalBlockWidth) / 2
            + blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop 
            - (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5
            - blockHeight / 2;

        // Add rows of blocks
        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blockPerRow; column++)
            {
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;

        if (randomBlockType < ConfigurationUtils.StandardProbability)
        {
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
        }
        else if (randomBlockType < ConfigurationUtils.StandardProbability
            + ConfigurationUtils.BonusProbability)
        {
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        }
        else
        {
            GameObject pickupBlock = Instantiate(prefabPickupBlock, position, Quaternion.identity);
            PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();

            if (randomBlockType < ConfigurationUtils.StandardProbability
            + ConfigurationUtils.BonusProbability + ConfigurationUtils.FreezerProbability)
            {
                pickupBlockScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                pickupBlockScript.Effect = PickupEffect.Speedup;
            }
        }

    }
}
