using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Material mat;
    private void Awake()
    {
        RenderSettings.skybox = mat;
    }

    public void LoadLevel(String lvlName)
    {
        SceneManager.LoadScene("BodySelect", LoadSceneMode.Single);
        SceneManager.LoadScene(lvlName, LoadSceneMode.Additive);
    }
}