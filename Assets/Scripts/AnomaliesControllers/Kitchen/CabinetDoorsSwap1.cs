using System;
using UnityEngine;

public class cabinetDoorsSwap1 : Anomaly
{
    [SerializeField] Transform firstObjectTransform;
    [SerializeField] Transform secondObjectTransform;
    public cabinetDoorsSwap1()
    {
        this.Type = Anomaly.Types[0]; //Object moved
        this.Room = 0; //Kitchen
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
