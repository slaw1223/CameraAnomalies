using System.Collections.Generic;
using UnityEngine;

public abstract class Anomaly : MonoBehaviour
{
    public static List<string> Types = new List<string> {"Object moved", "Object disappeared", "Extra object", "Intruder"};

    [SerializeField] public string name;
    public List<string> Type { get; protected set; } = new List<string>();
    public string Room { get; protected set; }
    public abstract void Appear();
    public abstract void Disappear();
}
