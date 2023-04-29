using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    float size = 0;
    public GameObject particle;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (size <= 0.33f)
        {
            size += Time.deltaTime;
            transform.localScale += Vector3.one * (3 * Time.deltaTime);
        }
        else
        {
            particle.SetActive(true);
            this.enabled = false;
        }
    }
}
