using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 1f;
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.position += transform.forward * speed * 1 * Time.deltaTime;
  }
}
