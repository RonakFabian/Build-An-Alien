using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPawn : MonoBehaviour
{

  public GameObject alien;
  public float speed = 15f;

  float horizontal;

  CameraShake cs;
  Vector3 pos;

  void Start()
  {

    cs = GetComponent<CameraShake>();

  }

  // Update is called once per frame
  void Update()
  {
    var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    transform.position += move * speed * Time.deltaTime;
    float clampx = Mathf.Clamp(transform.position.x, -2.6f, 2.6f);
    transform.position = new Vector3(clampx, transform.position.y, transform.position.z);
  }
}
