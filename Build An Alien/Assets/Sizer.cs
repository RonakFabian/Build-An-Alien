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
  void Update()
  {
    transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2, 2, 2), 0.001f * Time.deltaTime);
  }
}
