using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
  public GameObject bodySelectPanel;
  public GameObject spaceParent;
  public GameObject alien;
  public GameObject bodySelectCam;
  public GameObject planetSelect;
  public GameObject planetSelectHUD;
  public GameObject planetCam;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SwitchGameMode()
  {


    bodySelectCam.SetActive(true);
    bodySelectPanel.SetActive(false);
    alien.SetActive(false);
    bodySelectCam.SetActive(false);
    planetSelect.SetActive(true);
    planetSelectHUD.SetActive(true);
    planetCam.SetActive(true);
  }
}
