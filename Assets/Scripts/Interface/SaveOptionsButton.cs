using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveOptionsButton : MonoBehaviour
{
    [SerializeField] private OptionsHandler optionsHandler;
    Button button;
    Image buttonImage;

    Color enabledColor = new Color(0, 1f, 0.136f);
    Color disabledColor = Color.gray;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        disableButton();
    }

    public void OnButtonClicked()
    {
       optionsHandler.saveSettings();
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
