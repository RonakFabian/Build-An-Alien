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
  Vector3 move;

  bool moveLeft, moveRight;

  void Start()
  {

    cs = GetComponent<CameraShake>();

  }

  // Update is called once per frame
  void Update()
  {
    move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    transform.position += move * speed * Time.deltaTime;
    float clampx = Mathf.Clamp(transform.position.x, -2.8f, 2.8f);
    transform.position = new Vector3(clampx, transform.position.y, transform.position.z);

    if (moveLeft)
      MoveLeft();


    if (moveRight)
      MoveRight();

  }

  public void MoveLeft()
  {
    print("left");
    move = new Vector3(-1, 0, 0);
    transform.position += move * speed * Time.deltaTime;
    float clampx = Mathf.Clamp(transform.position.x, -2.8f, 2.8f);
    transform.position = new Vector3(clampx, transform.position.y, transform.position.z);

  }

  public void SetMoveLeft(bool l)
  {
    moveLeft = l;
  }

  public void SetMoveRight(bool r)
  {
    moveRight = r;
  }


  public void MoveRight()
  {
    print("right");
    move = new Vector3(1, 0, 0);
    transform.position += move * speed * Time.deltaTime;
    float clampx = Mathf.Clamp(transform.position.x, -2.8f, 2.8f);
    transform.position = new Vector3(clampx, transform.position.y, transform.position.z);
  }
}
