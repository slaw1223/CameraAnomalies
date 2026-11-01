using UnityEngine;
using UnityEngine.UI;

public class ResetOptionsButton : MonoBehaviour
{
    [SerializeField] private ResetOptionsPanel resetOptionsPanel;
    Button button;
    Image buttonImage;

    Color enabledColor = new Color(1f, 0.545f, 0);
    Color disabledColor = Color.gray;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        disableButton();
    }

    public void OnButtonClicked()
    {
        resetOptionsPanel.turnOnPanel();
    }

    public void enableButton()
    {
        buttonImage.color = enabledColor;
        button.interactable = true;
    }

    public void disableButton()
    {
        buttonImage.color = disabledColor;
        button.interactable = false;
    }
}
