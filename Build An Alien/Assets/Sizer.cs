using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sizer : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2, 2, 2), 0.0025f * Time.fixedDeltaTime);
  }
}
