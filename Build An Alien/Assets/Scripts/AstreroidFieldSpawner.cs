using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreroidFieldSpawner : MonoBehaviour
{
  public GameObject asteroidPrefab;
  public float radius = 500;
  public float count = 100;

  void Start()
  {
    for (int i = 0; i <= count; i++)
    {
      SpawnAsteroids();

    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  void SpawnAsteroids()
  {
    GameObject go = Instantiate(asteroidPrefab, Random.insideUnitSphere * radius + transform.position, Random.rotation);
    go.transform.SetParent(transform);

  }
}
