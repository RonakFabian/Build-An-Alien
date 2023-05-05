using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{
  public float timer;
  public List<GameObject> Prefabs;

  public float rateOfSpawn = 1;
  float currentTime = 0;


  public enum PlanetEnum
  {
    Mars,
    Mercury,
    Venus,
    Jupiter,
    Saturn,
    Uranus,
    Neptune

  }

  PlanetEnum planet;

  void Start()
  {
    SpawnRandomly();
  }

  // Update is called once per frame
  void Update()
  {
    currentTime += Time.deltaTime;
    if (currentTime >= rateOfSpawn)
    {
      currentTime = 0;
      SpawnRandomly();
    }
  }

  void SpawnRandomly()
  {

  }

  public void SetPlanet(int planet)
  {

  }

  public void StartGame()
  {

  }

  void SetPlanetDetails()
  {
    switch (planet)
    {
      case PlanetEnum.Mars:

        break;
    }
  }
}
