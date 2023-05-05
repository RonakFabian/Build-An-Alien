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
  int randInt;

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
    randInt = Random.Range(0, waypoints.Length - 1);
  }

  void Update()
  {
    if (canMove)
      Move();
  }

  void Move()
  {
    transform.position = Vector3.MoveTowards(transform.position, waypoints[randInt].transform.position, moveSpeed * Time.deltaTime);


    if (transform.position == waypoints[waypointIndex].transform.position)
    {

      randInt = Random.Range(0, waypoints.Length - 1);
    }

    // if (waypointIndex == waypoints.Length)
    //   waypointIndex = 0;

    Quaternion desiredRotation = Quaternion.LookRotation((transform.position - waypoints[randInt].transform.position).normalized);
    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
  }


}
