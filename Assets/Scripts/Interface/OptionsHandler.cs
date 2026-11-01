using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class OptionsHandler : MonoBehaviour
{
    public bool HasSomethingChanged
    {
        get { return _hasSomethingChanged; }
        set
        {
            _hasSomethingChanged = value;
            if (_hasSomethingChanged == true)
            {
                saveOptionsButton.enableButton();
                resetOptionsButton.enableButton();
            }
            else
            {
                saveOptionsButton.disableButton();
            }
        }
    }
    private bool _hasSomethingChanged = false;

    [SerializeField] ResetOptionsButton resetOptionsButton;
    [SerializeField] SaveOptionsButton saveOptionsButton;

    [SerializeField] private VolumeProfile volumeProfile;
    [SerializeField] private TitleScreenClickHandler titleScreenClickHandler;
    [SerializeField] private GameObject SaveOptionsConfirmationPanel;

    //-- options variables
    [SerializeField] private float defaultVignetteIntensity = 0.3f;
    float vignetteIntensity = 0.3f;
    [SerializeField] private float maxVignetteIntensity = 0.3f;
    [SerializeField] private TextMeshProUGUI vignetteIntensityValueText;
    [SerializeField] private Slider vignetteIntesnitySlider;

    [SerializeField] private float defaultChromaticAberrationIntensity = 0.3f;
    float chromaticAberrationIntensity = 0.3f;
    [SerializeField] private float maxChromaticAberrationIntensity = 0.3f;
    [SerializeField] private TextMeshProUGUI chromaticAberrationIntensityValueText;
    [SerializeField] private Slider chromaticAberrationIntensitySlider;

    [SerializeField] private float defaultGrainIntensity = 0.1f;
    float grainIntensity = 0.1f;
    [SerializeField] private float maxGrainIntensity = 0.15f;
    [SerializeField] private TextMeshProUGUI grainIntensityValueText;
    [SerializeField] private Slider grainIntensitySlider;
    void Start()
    {
        SaveOptionsConfirmationPanel.SetActive(false);

        loadSettings();

        vignetteIntesnitySlider.maxValue = maxVignetteIntensity;
        chromaticAberrationIntensitySlider.maxValue = maxChromaticAberrationIntensity;
        grainIntensitySlider.maxValue = maxGrainIntensity;
    }

    public void loadSettings()
    {
        vignetteIntensity = PlayerPrefs.GetFloat("VignetteIntensity", defaultVignetteIntensity);
        vignetteIntesnitySlider.value = vignetteIntensity;
        onVignetteIntenistySliderChanged();
        chromaticAberrationIntensity = PlayerPrefs.GetFloat("ChromaticAberrationIntensity", defaultChromaticAberrationIntensity);
        chromaticAberrationIntensitySlider.value = chromaticAberrationIntensity;
        onChromaticAberrationSliderChanged();
        grainIntensity = PlayerPrefs.GetFloat("GrainIntensity", defaultGrainIntensity);
        grainIntensitySlider.value = grainIntensity;
        onGrainIntensitySliderChanged();

        if(PlayerPrefs.GetInt("AreOptionsDifferentFromDefault", 0) == 1)
        {
            resetOptionsButton.enableButton();
        }
        else
        {
            resetOptionsButton.disableButton();
        }
        HasSomethingChanged = false;
    }

    public void resetSettings()
    {
        vignetteIntesnitySlider.value = defaultVignetteIntensity;
        chromaticAberrationIntensitySlider.value = defaultChromaticAberrationIntensity;
        grainIntensitySlider.value = defaultGrainIntensity;
        PlayerPrefs.SetInt("AreOptionsDifferentFromDefault", 0);
        resetOptionsButton.disableButton();
        saveSettings();
    }

    public void saveSettings()
    {
        if(HasSomethingChanged == true)
        {
            PlayerPrefs.SetFloat("VignetteIntensity", vignetteIntesnitySlider.value);
            PlayerPrefs.SetFloat("ChromaticAberrationIntensity", chromaticAberrationIntensitySlider.value);
            PlayerPrefs.SetFloat("GrainIntensity", grainIntensitySlider.value);

            PlayerPrefs.SetInt("AreOptionsDifferentFromDefault", 1);
            HasSomethingChanged = false;
        }
    }


    //-- eixt options
    public void exitButtonClicked()
    {
        if (HasSomethingChanged)
        {
            SaveOptionsConfirmationPanel.SetActive(true);
            HasSomethingChanged = false;
        }
        else titleScreenClickHandler.ExitToMainMenuButtonClicked();
    }

    public void saveAndExitButtonClicked()
    {
        saveSettings();
        SaveOptionsConfirmationPanel.SetActive(false);
        titleScreenClickHandler.ExitToMainMenuButtonClicked();
    }

    public void exitWithoutSavingButtonClicked()
    {
        loadSettings();
        SaveOptionsConfirmationPanel.SetActive(false);
        titleScreenClickHandler.ExitToMainMenuButtonClicked();
    }

    //-- sliders
    public void onVignetteIntenistySliderChanged()
    {
        vignetteIntensity = vignetteIntesnitySlider.value;
        vignetteIntensityValueText.text = Mathf.Ceil(vignetteIntensity / maxVignetteIntensity * 100).ToString() + " %";

        volumeProfile.TryGet<Vignette>(out var vignette);
        if (vignette != null)
        {
            vignette.intensity.value = vignetteIntensity;
        }
        HasSomethingChanged = true;
    }

    public void onChromaticAberrationSliderChanged()
    {
        chromaticAberrationIntensity = chromaticAberrationIntensitySlider.value;
        chromaticAberrationIntensityValueText.text = Mathf.Ceil(chromaticAberrationIntensity / maxChromaticAberrationIntensity * 100).ToString() + " %";

        volumeProfile.TryGet<ChromaticAberration>(out var chromaticAberration);
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = chromaticAberrationIntensity;
        }
        HasSomethingChanged = true;
    }

    public void onGrainIntensitySliderChanged()
    {
        grainIntensity = grainIntensitySlider.value;
        grainIntensityValueText.text = Mathf.Ceil(grainIntensity / maxGrainIntensity * 100).ToString() + " %";
        volumeProfile.TryGet<FilmGrain>(out var filmGrain);
        if (filmGrain != null)
        {
            filmGrain.intensity.value = grainIntensity;
        }
        HasSomethingChanged = true;
    }
}
