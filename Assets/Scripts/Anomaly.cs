using System.Collections.Generic;
using UnityEngine;

public abstract class Anomaly : MonoBehaviour
{
    public static List<string> Types = new List<string> {"Object moved", "Object disappeared", "Extra object", "Intruder"};

    [SerializeField] public string anomalyName;
    
    public string Type;

    [SerializeField] public int Room;
    public abstract void Appear();
    public abstract void Disappear();
}
