using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TitleScreenClickHandler : MonoBehaviour
{
    [SerializeField] Transform titleScreenTransform;
    [SerializeField] Transform chooseMapTransform;

    private string difficulty = "Normal   x1";
    private Dictionary<string, float> difficulties = new Dictionary<string, float> { { "Easy", 0.5f }, { "Normal", 1f }, { "Hard", 2f } };

    [SerializeField] TextMeshProUGUI difficultyText;
    void Start()
    {
        titleScreenTransform.gameObject.SetActive(true);
        chooseMapTransform.gameObject.SetActive(false);
        difficultyText.text = difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButtonClicked()
    {
        titleScreenTransform.gameObject.SetActive(false);
        chooseMapTransform.gameObject.SetActive(true);
    }

    public void ExitToMainMenuButtonClicked()
    {
        titleScreenTransform.gameObject.SetActive(true);
        chooseMapTransform.gameObject.SetActive(false);
    }

    public void StartShiftButtonClicked()
    {
        //TODO tell game the difficulty
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstHouseScene");
    }    

    public void QuitButtonClicked()
    {
        Debug.Log("Quit button clicked.");
        Application.Quit();
    }

    public void OptionsButtonClicked()
    {
        //TODO mate
    }

    public void DifficultyButtonClicked()
    {
        int index = difficulties.Keys.ToList().IndexOf(difficulty);
        if (difficulties.Count() > index + 1)
        {
            difficulty = difficulties.Keys.ToList()[index + 1];
        }
        else
        {
            difficulty = difficulties.Keys.ToList()[0];
        }
        difficultyText.text = difficulty + "   x" + difficulties[difficulty].ToString();
    }
}
