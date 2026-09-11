using UnityEngine;
using UnityEngine.UI;

public class AnomalyEntry : MonoBehaviour
{
    public AnomaliesManager anomaliesManager;
    [SerializeField] TMPro.TextMeshProUGUI anomalyNameText;
    [SerializeField] Button appearButton;
    [SerializeField] Button disappearButton;
    [SerializeField] Button reportButton;

    // This function should get an anomaly object from anomalies manager
    public void SetAnomaly(Anomaly anomaly)
    {
        anomalyNameText.text = anomaly.name;
        //TO DO 
        //POPRAWNE DODAWANIE ANOMALI DO AKTYWNYCH
        appearButton.onClick.AddListener(() => anomaly.Appear());
        disappearButton.onClick.AddListener(() => anomaly.Disappear());
        reportButton.onClick.AddListener(() => anomaliesManager.reportAnomaly(anomaly.Type, anomaly.Room));
    }
}
