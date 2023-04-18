using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPawn : MonoBehaviour
{
  public float forwardSpeed = 25f;
  public float strafeSpeed = 7.5f;
  public float hoverSpeed = 5f;

  private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
  private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

  public float lookRotateSpeed = 90f;
  private Vector2 lookInput, screenCenter, mouseDistance;

  private float rollInput;
  private float rollSpeed = 90f, rollAcceleration = 3.5f;

  void Start()
  {
    screenCenter.x = Screen.width * .5f;
    screenCenter.y = Screen.height * .5f;

    Cursor.lockState = CursorLockMode.Confined;

  }

  // Update is called once per frame
  void Update()
  {
    lookInput.x = Input.mousePosition.x;
    lookInput.y = Input.mousePosition.y;

    mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
    mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

    mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

    rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
    transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

    activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
    activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
    activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

    transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
    transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
  }
}
