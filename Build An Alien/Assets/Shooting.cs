using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public float rateOfFire = 0.5f;
  float prevFire;
  public GameObject bulletPrefab;
  public Transform target;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    prevFire += Time.deltaTime;
    if (Input.GetMouseButton(0))
    {
      if (prevFire >= rateOfFire)
      {
        prevFire = 0;
        Shoot();
      }
    }
  }

  void Shoot()
  {
    print("Shoot");
    GameObject go = Instantiate(bulletPrefab, target.transform.position, target.transform.rotation);

  }
}
