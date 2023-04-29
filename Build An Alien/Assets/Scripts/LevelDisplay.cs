using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
  public TMP_Text Text;
  void Start()
  {
    Display();
  }

  public void Display()
  {
    if (PlayerPrefs.GetInt("SavedLevel") < 3)
      PlayerPrefs.SetInt("SavedLevel", 3);
    Text.text = "Level " + (PlayerPrefs.GetInt("SavedLevel") - 2).ToString();
  }
}
