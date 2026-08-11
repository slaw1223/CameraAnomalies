using System;
using UnityEngine;

public class twoObjectsSwapAnomalyController : Anomaly
{
    [SerializeField] Transform firstObjectTransform;
    [SerializeField] Transform secondObjectTransform;
    public twoObjectsSwapAnomalyController()
    {
        this.Type.Add(Anomaly.Types[0]); //Object moved
    }

    public override void Appear()
    {
        swapObjects();
    }

    public override void Disappear()
    {
        swapObjects();
    }

    private void swapObjects()
    {
        Vector3 container = firstObjectTransform.position;
        firstObjectTransform.position = secondObjectTransform.position;
        secondObjectTransform.position = container;
    }
}
