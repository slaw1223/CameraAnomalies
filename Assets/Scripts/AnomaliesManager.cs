using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AnomaliesManager : MonoBehaviour
{
    [SerializeField] List<Anomaly> inactiveAnomalies;
    List<Anomaly> activeAnomalies;


    // Anomalies will appear at random intervals between minimal and maximum time
    int minimalTimeBetweenAnomaliesAppearance = 10;
    int maximumTimeBetweenAnomaliesAppearance = 30;

    // When anomalies reach soft limit, player will be warned, when anomalies reach hard limit, player will lose
    int softAnomaliesLimit = 5;
    int hardAnomaliesLimit = 10;

    float timeToNextAnomaly;
    void Start()
    {
        //Gives player some time to adjust to a map
        timeToNextAnomaly = 30;
    }

    void Update()
    {
        timeToNextAnomaly -= Time.deltaTime;
        if(timeToNextAnomaly <= 0)
        {
            createAnomaly();
            timeToNextAnomaly = Random.Range(minimalTimeBetweenAnomaliesAppearance, maximumTimeBetweenAnomaliesAppearance);
        }
    }

    void createAnomaly()
    {
        if (activeAnomalies.Count == hardAnomaliesLimit)
        {
            //TODO
            // Loose player
            return;
        }
        else if (activeAnomalies.Count == softAnomaliesLimit)
        {
            //TODO
            // Warn player
        }

        int randomIndex = Random.Range(0, inactiveAnomalies.Count);
        Anomaly anomaly = inactiveAnomalies[randomIndex];
        activeAnomalies.Add(anomaly);
        inactiveAnomalies.RemoveAt(randomIndex);

        anomaly.Appear();
    }

    void reportAnomaly(string type, string room)
    {
        foreach(Anomaly anomaly in activeAnomalies)
        {
            foreach(string anomalyType in anomaly.Type)
            {
                if (anomalyType == type && anomaly.Room == room)
                {
                    //TODO
                    // Message success to a player
                    anomaly.Disappear();
                    return;
                }
            }
        }
        //TODO
        // Message to a player that anomaly does not exist
    }
}


