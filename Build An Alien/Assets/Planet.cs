using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
  public GameObject planetMode;
  public GameObject spaceShipMode;
  public GameObject spaceShip;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartShipMode()
  {
    spaceShipMode.SetActive(true);
    spaceShip.SetActive(true);
    planetMode.SetActive(false);

  }
}
