using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DisplayScene : MonoBehaviour
{
    public void RoundSelection(int _)
    {
        SceneManager.LoadScene(_);
    }
    public void AudioButton()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.button);
    }
}
