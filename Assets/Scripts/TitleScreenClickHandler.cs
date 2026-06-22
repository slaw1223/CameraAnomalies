using UnityEngine;

public class TitleScreenClickHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButtonClicked()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("NextSceneName");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
