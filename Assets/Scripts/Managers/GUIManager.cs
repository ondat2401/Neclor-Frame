using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class GUIManager : MonoBehaviour
{
    public GameObject EndPanel;
    public GameObject OptionPanel;

    public Slider musicSlider;
    private void Update()
    {
        if (instance.currentState == GameState.GameOver)
            EndPanel.SetActive(true);

        if(OptionPanel.activeSelf && AudioManager.instance != null)
            AudioManager.instance.musicSource.volume = musicSlider.value;

    }
    public void PlayButton()
    {
        instance.PlayButton();
        AudioManager.instance.PlaySFX(AudioManager.instance.button);

    }
    public void RestartButton()
    {
        SceneLoadeManager.instance.ReloadScene();
        AudioManager.instance.PlaySFX(AudioManager.instance.button);
    }
    public void GoToMainMenu()
    {
        instance.GoToMainMenu();
        AudioManager.instance.PlaySFX(AudioManager.instance.button);
    }
    public void OptionClicked()
    {
        if (instance.currentState == GameState.Paused)
        {
            OptionPanel.SetActive(true);
            instance.currentState = GameState.Option;
            AudioManager.instance.PlaySFX(AudioManager.instance.button);
        }

    }
    public void ResumeClicked()
    {
        OptionPanel.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.button);
        instance.currentState = GameState.Paused;
    }
    public void QuitClicked()
    {
        SceneLoadeManager.instance.LoadSceneByName("MainMenu");
        AudioManager.instance.PlaySFX(AudioManager.instance.button);
    }
}
