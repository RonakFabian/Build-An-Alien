using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public float rateOfFire = 0.5f;

  public int health = 100;
  float prevFire;
  public GameObject bulletPrefab;
  public GameObject hitPrefab;
  public Transform target;
  public Transform alienTarget;

  public TMPro.TMP_Text healthTxt;
  public TMPro.TMP_Text ammoTxt;

  bool canShoot = true;

  public int maxAmmo;
  int currentAmmo;
  void Start()
  {
    currentAmmo = maxAmmo;
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
        if (currentAmmo > 0)
          Shoot();
      }
    }
  }

  void Shoot()
  {

    GameObject go = Instantiate(bulletPrefab, target.transform.position, target.transform.rotation);
    currentAmmo--;
    ammoTxt.text = "Ammo: " + currentAmmo + "/" + maxAmmo;


  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == ("Enemy"))
    {
      print("Hit");

      TakeDamage();
      Destroy(other.gameObject);
    }

  }

  void TakeDamage()
  {
    if (health > 0)
    {
      health -= 50;
      healthTxt.text = "Health: " + health;
      GameObject go = Instantiate(hitPrefab, alienTarget.transform.position, Quaternion.identity);
      Destroy(go, 2);
    }
    //stop game
  }

  public void AmmoReset()
  {
    currentAmmo = maxAmmo;
    ammoTxt.text = "Ammo: " + currentAmmo + "/" + maxAmmo;

  }
}
