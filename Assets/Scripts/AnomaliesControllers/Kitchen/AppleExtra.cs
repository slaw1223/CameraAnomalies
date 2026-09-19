using UnityEngine;

public class appleExtra : Anomaly
{
    [SerializeField] GameObject appleExtraObject;
    appleExtra()
    {
        this.Type = Anomaly.Types[2]; //Extra object
        this.Room = 0; //Kitchen
    }
    public override void Appear()
    {
        appleExtraObject.SetActive(true);
    }

    public override void Disappear()
    {
        appleExtraObject.SetActive(false);
    }
}
