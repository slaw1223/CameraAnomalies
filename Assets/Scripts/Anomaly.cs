using System.Collections.Generic;
using UnityEngine;

public abstract class Anomaly
{
    public static List<string> Types = new List<string> {"Object moved", "Object disappeared", "Extra object", "Intruder"};
    public List<string> Type { get; protected set; }
    public string Room { get; protected set; }
    public abstract void Appear();
    public abstract void Disappear();
}
