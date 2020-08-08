using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Variables
    public string levelToLoad = "LevelSelect";

    public SceneFader sceneFader;
    #endregion

    #region Methods
    public void Play()
	{
        sceneFader.FadeTo(levelToLoad);
	}

    public void Quit()
	{
        Debug.Log("Exiting...");
        Application.Quit();
	}
    #endregion
}