using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 1f;
  public GameObject prefab;
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.position += transform.forward * speed * 1 * Time.deltaTime;
  }


  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == ("Enemy"))
    {
      print("Hit");
      GameObject go = Instantiate(prefab, other.gameObject.transform.position, Quaternion.identity);
      go.transform.localScale *= 0.5f;
      Destroy(this.gameObject);
      Destroy(other.gameObject);
      Destroy(go, 2);
    }
  }


}
