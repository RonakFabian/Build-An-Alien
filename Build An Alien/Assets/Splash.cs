using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
  public GameObject hud;
  public GameObject alien;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      hud.SetActive(true);
      alien.SetActive(true);
      gameObject.SetActive(false);
    }
  }
}
