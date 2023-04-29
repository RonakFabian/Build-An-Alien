using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Material mat;
    public Color color;
    public float startVal;
    public float endVal;
    public bool isLevelSettings = false;
    

    private void Awake()
    {
         if (isLevelSettings)
         {
        RenderSettings.ambientLight = new Color(1.49803925f, 1.49803925f, 1.49803925f, 1);
         }
    }

    public void SetSkyboxSettings()
    {
        RenderSettings.skybox = mat;
        RenderSettings.fog = true;
        RenderSettings.fogColor = color;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = startVal;
        RenderSettings.fogEndDistance = endVal;
        RenderSettings.ambientLight = new Color(1.18807995f, 1.35177505f, 1.45759797f, 1);
    }

    public void OnGameStarted()
    {
        Invoke("UnLoadScene", 2f);
    }

    void UnLoadScene()
    {
        SceneManager.UnloadSceneAsync("BodySelect");
    }
}