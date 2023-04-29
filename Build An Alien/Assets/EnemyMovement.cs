using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  public GameObject waypointParent;
  Transform[] waypoints;

  [SerializeField]
  float moveSpeed = 2f;


  [SerializeField]
  float rotationSpeed = 2f;

  Vector3 dir;


  int waypointIndex = 0;

  bool canMove = false;
  Rigidbody rb;

  void Start()
  {
    Invoke("SetWaypoints", 1);
    rb = GetComponent<Rigidbody>();
  }

  private void SetWaypoints()
  {
    waypoints = waypointParent.transform.GetComponentsInChildren<Transform>();
    transform.position = waypoints[waypointIndex].transform.position;
    canMove = true;
  }

  void Update()
  {
    if (canMove)
      Move();
  }

  void Move()
  {
    transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);


    if (transform.position == waypoints[waypointIndex].transform.position)
    {
      waypointIndex += 1;
    }

    if (waypointIndex == waypoints.Length)
      waypointIndex = 0;

    Quaternion desiredRotation = Quaternion.LookRotation((transform.position - waypoints[waypointIndex].transform.position).normalized);
    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
  }


}
