using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneLoadeManager;

public class ButtonSetting : MonoBehaviour
{
    public void OnNextRoundBtn()
    {
        instance.LoadNextSceneByIndex();
        GameManager.instance.currentSceneCount++;
    }
    public void OnRestartRoundBtn()
    {
        instance.ReloadScene();

    }
}
