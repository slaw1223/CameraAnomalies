using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnomaliesManager : MonoBehaviour
{
    public GameObject reportInfoPanel;
    public TextMeshProUGUI reportInfoText;

    [SerializeField] List<Anomaly> inactiveAnomalies;
    List<Anomaly> activeAnomalies = new List<Anomaly>();
    public CameraController cameraController;


    // Anomalies will appear at random intervals between minimal and maximum time
    [SerializeField] int minimalTimeBetweenAnomaliesAppearance = 10;
    [SerializeField] int maximumTimeBetweenAnomaliesAppearance = 30;

    // When anomalies reach soft limit, player will be warned, when anomalies reach hard limit, player will lose
    [SerializeField] int softAnomaliesLimit = 5;
    [SerializeField] int hardAnomaliesLimit = 10;

    [SerializeField] float timeToNextAnomaly;

    private float cooldown = 0;

    public List<Anomaly> availableAnomalies = new List<Anomaly>();
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

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            reportInfoPanel.SetActive(false);
        }
    }

    public void createAnomaly()
    {
        if (activeAnomalies.Count == hardAnomaliesLimit)
        {
            //TODO
            // Loose player
            return;
        }
        else if (activeAnomalies.Count == softAnomaliesLimit)
        {
            reportInfoPanel.SetActive(true);
            reportInfoText.text = "soft limit alert";
            cooldown = 6.5f;
            //TODO
            // Warn player
        }


        int randomRoom = Random.Range(0, cameraController.availableLocations.Count);
        randomRoom = 0;
        

        foreach (Anomaly anomaly in inactiveAnomalies)
        {
            if (anomaly.Room == randomRoom)
            {
                bool roomHasAnomaly = false;

                foreach (Anomaly activeAnomaly in activeAnomalies)
                {
                    if (activeAnomaly.Room == randomRoom)
                    {
                        roomHasAnomaly = true;
                        break;
                    }
                }

                if (!roomHasAnomaly)
                {
                    availableAnomalies.Add(anomaly);
                }
            }
        }

        if (availableAnomalies.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, availableAnomalies.Count);
        Anomaly selectedAnomaly = availableAnomalies[randomIndex];

        activeAnomalies.Add(selectedAnomaly);
        inactiveAnomalies.Remove(selectedAnomaly);
        availableAnomalies.Clear();

        selectedAnomaly.Appear();
    }

    public void reportAnomaly(string type, int room)
    {
        foreach(Anomaly anomaly in activeAnomalies)
        {
            if (anomaly.Type == type && anomaly.Room == room)
            {
                reportInfoPanel.SetActive(true);
                reportInfoText.text = "Anomaly succesfully spotted";
                cooldown = 6.5f;

                //TODO
                // Message success to a player
                anomaly.Disappear();
                inactiveAnomalies.Add(anomaly);
                activeAnomalies.Remove(anomaly);
                return;
            }
        }
        reportInfoPanel.SetActive(true);
        reportInfoText.text = "No anomaly spotted";
        cooldown = 6.5f;
        //TODO
        // Message to a player that anomaly does not exist
    }
}


