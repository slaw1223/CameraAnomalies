using UnityEngine;

public class ResetOptionsPanel : MonoBehaviour
{
    [SerializeField] private OptionsHandler optionsHandler;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void turnOnPanel()
    {
        gameObject.SetActive(true);
    }

    public void noButtonClicked()
    {
        gameObject.SetActive(false);
    }

    public void yesButtonClicked()
    {
        gameObject.SetActive(false);
        optionsHandler.resetSettings();
    }
}
