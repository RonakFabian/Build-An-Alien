using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
  public float radius = 500;
  public float count = 10;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SpawnEnemyWayPoints()
  {
    for (int i = 0; i <= count; i++)
    {
      GameObject go = new GameObject("Enemy_Waypoint");
      transform.position = Random.insideUnitSphere * radius + transform.position;
      go.transform.SetParent(transform);
    }
  }
}
