using Unity.VisualScripting;
using UnityEngine;

public class ReportAnomalyController : MonoBehaviour
{
    //"Object moved", "Object disappeared", "Extra object", "Intruder"
    public GameObject reportPanel;
    public GameObject reportCooldownPanel;

    public AnomaliesManager anomaliesManager;
    public CameraController cameraController;
    

    private float cooldown = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            reportCooldownPanel.SetActive(false);
        }
    }

    public void OpenAnomalyReportScreen()
    {
        reportPanel.SetActive(true);
    }

    public void CloseAnomalyReportScreen()
    {
        reportPanel.SetActive(false);
    }

    public void ReportAnomaly(string type)
    {
        Debug.Log("Reported: " + type);
        anomaliesManager.reportAnomaly(type, cameraController.currentLocationIndex);
        reportCooldownPanel.SetActive(true);
        cooldown = 1.5f;
    }
}
