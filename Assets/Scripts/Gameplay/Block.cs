using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A Block
/// </summary>
public class Block : MonoBehaviour
{
    // Scoring support
    protected int points;
    PointsAdded pointsAdded;

    // Endgame support
    AllBlockDestroyed allBlockDestroyed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        pointsAdded = new PointsAdded();
        EventManager.AddPointsAddedInvoker(this);

        allBlockDestroyed = new AllBlockDestroyed();
        EventManager.AddAllBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Destroy the block on collision with a ball
    /// </summary>
    /// <param name="coll"></param>
    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            pointsAdded.Invoke(points);
            allBlockDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener(UnityAction<int> points)
    {
        pointsAdded.AddListener(points);
    }

    public void AddAllBlockDestroyedListener(UnityAction listener)
    {
        allBlockDestroyed.AddListener(listener);
    }
}
