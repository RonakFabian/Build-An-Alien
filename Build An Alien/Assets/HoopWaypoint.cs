using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopWaypoint : MonoBehaviour
{
  [SerializeField]
  List<GameObject> hoops;
  int currentIndex = 0;
  int maxIndex = 0;

  void Start()
  {

  }




  void DisableAllWaypoints()
  {
    foreach (GameObject g in hoops)
    {
      g.SetActive(false);
    }
  }

  void SetNextHoopActive()
  {

    currentIndex++;
    hoops[currentIndex].SetActive(true);

  }

}
