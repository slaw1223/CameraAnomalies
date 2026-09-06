using UnityEngine;

public class AppearDevPanelButtonController : MonoBehaviour
{
    [SerializeField] Transform DevPanelTransform;

    public void AppearDevPanelButtonClicked()
    {
        DevPanelTransform.gameObject.SetActive(!DevPanelTransform.gameObject.activeSelf);
    }
}
