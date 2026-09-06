using UnityEngine;

public class ReportAnomalyController : MonoBehaviour
{
    //"Object moved", "Object disappeared", "Extra object", "Intruder"
    public GameObject ReportPanel;

    public AnomaliesManager anomaliesManager;
    public CameraController cameraController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAnomalyReportScreen()
    {
        ReportPanel.SetActive(true);
    }

    public void CloseAnomalyReportScreen()
    {
        ReportPanel.SetActive(false);
    }

    public void ReportAnomaly(string type)
    {
        Debug.Log("Reported: " + type);
        anomaliesManager.reportAnomaly(type, cameraController.currentLocationIndex);
    }
}
