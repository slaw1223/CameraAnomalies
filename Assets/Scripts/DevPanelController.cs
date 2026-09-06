using UnityEngine;

public class DevPanelController : MonoBehaviour
{
    [SerializeField] AnomaliesManager anomaliesManager;
    [SerializeField] GameObject anomalyEntryPreset;
    [SerializeField] Transform anomaliesListPanel;

    void Start()
    {
        populatePanelWithAnomalies();
    }

    void populatePanelWithAnomalies()
    {
        foreach (Transform child in anomaliesManager.transform)
        {
            GameObject anomalyEntryObject = Instantiate(anomalyEntryPreset, transform);
            anomalyEntryObject.transform.SetParent(anomaliesListPanel, false);

            AnomalyEntry anomalyEntry = anomalyEntryObject.GetComponent<AnomalyEntry>();
            anomalyEntry.SetAnomaly(child.GetComponent<Anomaly>());
            anomalyEntry.anomaliesManager = anomaliesManager;
        }
    }

    public void appearRandomAnomaly()
    {
        anomaliesManager.createAnomaly();
    }
}
