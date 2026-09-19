using UnityEngine;

public class KitchenDoorDespawn : Anomaly
{
    [SerializeField] GameObject door;

    KitchenDoorDespawn()
    {
        this.Type = Anomaly.Types[1]; //Object despawned
        this.Room = 1; //LivingRoom
    }

    public override void Appear()
    {
        door.SetActive(false);
    }

    public override void Disappear()
    {
        door.SetActive(true);
    }
}
