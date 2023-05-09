using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreroidFieldSpawner : MonoBehaviour
{
  public List<GameObject> asteroidPrefabs;
  public float radius = 500;
  public float count = 100;
  public float speed = 1;

  void Start()
  {

    SpawnAsteroids();

  }



  public void SpawnAsteroids()
  {
    for (int i = 0; i <= count; i++)
    {
      GameObject go;
      int randInt = Random.Range(0, 3);
      int randIntSize = Random.Range(4, 8);

      go = Instantiate(asteroidPrefabs[randInt], Random.insideUnitSphere * radius + transform.position, Random.rotation);
      go.transform.SetParent(transform);
      go.transform.localScale *= randIntSize;

    }
  }

  public void SpawnPickups()
  {
    for (int i = 0; i <= count; i++)
    {
      GameObject go;
      go = Instantiate(asteroidPrefabs[0], Random.insideUnitSphere * radius + transform.position, Random.rotation);
      go.transform.SetParent(transform);
    }
  }

  void FixedUpdate()
  {
    transform.position -= Vector3.forward * speed * Time.fixedDeltaTime;
  }




}
