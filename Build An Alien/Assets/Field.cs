using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
  public float speed = 1;
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.position -= Vector3.forward * speed * Time.fixedDeltaTime;
  }

}
