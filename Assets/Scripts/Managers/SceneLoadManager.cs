using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class SceneLoadeManager : MonoBehaviour
{
    public static SceneLoadeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextSceneByIndex()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        switch (scene.name)
        {
            case "MainMenu":
                SetupMainMenu();
                break;
            case "GameOver":
                SetupGameOver();
                break;
            default:
                SetupGame();
                break;
        }
    }

    private void SetupMainMenu()
    {
        Debug.Log("Setting up MainMenu...");
    }

    private void SetupGame()
    {
        Debug.Log("Setting up Game scene...");
        GameManager.instance.player = FindObjectOfType<Player>();
        GameManager.instance.currentFrameCount = FindObjectOfType<FrameManager>().frameCount;
        GameManager.instance.ChangeState(GameState.Paused);
    }
    private void SetupGameOver()
    {
        Debug.Log("Setting up GameOver...");
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
