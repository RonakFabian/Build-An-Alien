using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject InGamePanel;
    public GameObject BodySelectPanel;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetUIMode(UIPanel panel)
    {
        DisableAllUI();
        switch (panel)
        {
            case UIPanel.InGamePanel:
                InGamePanel.SetActive(true);
                break;
            case UIPanel.BodySelectPanel:
                BodySelectPanel.SetActive(true);
                break;
        }
    }

    void DisableAllUI()
    {
        InGamePanel.SetActive(false);
        BodySelectPanel.SetActive(false);
    }

    public void SetUIPanel(int i)
    {
        SetUIMode((UIPanel)i);
    }
}
[Serializable]
public enum UIPanel:int
{
    InGamePanel,
    BodySelectPanel,
    GameOver,
    Pause,
    Settings
}