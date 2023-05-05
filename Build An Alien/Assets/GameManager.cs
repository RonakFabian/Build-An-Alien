using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;

  [HideInInspector]
  public int collectableScore = 0;
  public TMPro.TMP_Text collectableScoreTxt;
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

  public void AddScore()
  {
    collectableScore++;
    if (collectableScore >= 10)
    {
      print("Waypoints!!");
      collectableScoreTxt.gameObject.SetActive(false);
    }
    else
    {
      collectableScoreTxt.text = "Collect 10 Pickups :" + collectableScore + "/10";
    }

  }

}
