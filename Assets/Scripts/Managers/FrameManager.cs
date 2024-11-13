using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    public int frameCount;
    public TMP_Text text;
    private void Update()
    {
        text.text = "x " + GameManager.instance.currentFrameCount;
    }
}
