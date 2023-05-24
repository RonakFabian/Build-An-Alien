using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
  public TMPro.TMP_Text text;

  Color textColor;
  public float speed = 5;

  void Start()
  {
    textColor = text.gameObject.GetComponent<Color>();
  }

  // Update is called once per frame
  void Update()
  {
    textColor.a = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
    text.color = textColor;
  }
}
