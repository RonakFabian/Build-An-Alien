using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  //public int sceneNumber;
  public void Start()
  {
    int currentlvl = (PlayerPrefs.GetInt("SavedLevel"));

    if (currentlvl < 3)
      PlayerPrefs.SetInt("SavedLevel", 3);


  }
  public void LoadLevel(String lvlName)
  {
    SceneManager.UnloadSceneAsync("Main Menu");
    SceneManager.LoadScene("BodySelect", LoadSceneMode.Single);
    SceneManager.LoadScene(lvlName, LoadSceneMode.Additive);
  }

  public void LoadNextLevel()
  {
    SceneManager.UnloadSceneAsync("Main Menu");
    SceneManager.LoadScene("BodySelect", LoadSceneMode.Single);
    SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"), LoadSceneMode.Additive);
  }

  public void LoadNextLevelNoMenu()
  {
    SceneManager.LoadScene("BodySelect", LoadSceneMode.Single);
    SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"), LoadSceneMode.Additive);
  }

  public void RestartLevel()
  {
    SceneManager.LoadScene("Main Menu");
    SceneManager.LoadScene("BodySelect", LoadSceneMode.Single);
    SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"), LoadSceneMode.Additive);
  }


  public void SetNextLevel(int i)
  {
    PlayerPrefs.SetInt("SavedLevel", i);
  }


  public void Menu()
  {
    SceneManager.LoadScene("Main Menu");
  }

  public void SetUpgradeLevel(int i)
  {
    PlayerPrefs.SetInt("MaxUnlock", i);
  }

}
