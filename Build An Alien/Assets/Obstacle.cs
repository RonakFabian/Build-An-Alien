using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  public float speed = 10f;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.position -= Vector3.forward * speed * Time.deltaTime;
  }
}
