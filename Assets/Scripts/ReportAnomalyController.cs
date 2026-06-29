using UnityEngine;

public class ReportAnomalyController : MonoBehaviour
{
    public GameObject reportPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportButtonClicked()
    {
        reportPanel.SetActive(true);
    }

    public void CancelButtonClicked()
    {
        reportPanel.SetActive(false);
    }
}
