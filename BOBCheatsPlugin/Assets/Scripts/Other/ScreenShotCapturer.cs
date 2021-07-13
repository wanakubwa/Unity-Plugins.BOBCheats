using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotCapturer : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private int screenshotScale = 1;
    [SerializeField]
    private string fileName = "screenshot.png";

    #endregion

    #region Propeties

    public int ScreenshotScale
    {
        get => screenshotScale;
        private set => screenshotScale = value;
    }

    public string FileName
    {
        get => fileName;
        private set => fileName = value;
    }

    #endregion

    #region Methods

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11) == true)
        {
            ScreenCapture.CaptureScreenshot(FileName, ScreenshotScale);
        }
    }

    #endregion

    #region Enums



    #endregion
}
