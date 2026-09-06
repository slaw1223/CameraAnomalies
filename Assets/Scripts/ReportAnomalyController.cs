using UnityEngine;

public class ReportAnomalyController : MonoBehaviour
{
    //"Object moved", "Object disappeared", "Extra object", "Intruder"
    public GameObject ReportPanel;

    AnomaliesManager anomaliesManager;
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

    public void ReportObjMoved()
    {
        Debug.Log("Reported: Object moved");
        anomaliesManager.reportAnomaly("Object moved", 0);
    }

    public void ReportObjDisappeared()
    {
        Debug.Log("Reported: Object disappeared");
        anomaliesManager.reportAnomaly("Object disappeared", 0);
    }

    public void ReportObjExtra()
    {
        Debug.Log("Reported: Extra object");
    }

    public void ReportObjIntruder()
    {
        Debug.Log("Reported: Intruder");
    }
}
