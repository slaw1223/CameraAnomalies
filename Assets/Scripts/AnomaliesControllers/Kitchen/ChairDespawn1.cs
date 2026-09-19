using UnityEngine;

public class ChairDespawn1 : Anomaly
{
    [SerializeField] GameObject chair;
    
    ChairDespawn1()
    {
        this.Type = Anomaly.Types[1]; //Object despawned
        this.Room = 0; //Kitchen
    }

    public override void Appear()
    {
        chair.SetActive(false);
    }

    public override void Disappear()
    {
        chair.SetActive(true);
    }
}
