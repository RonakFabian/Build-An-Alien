using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowCounter : MonoBehaviour
{
    public int row = 0;
    public Vector3 pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp((transform.position), new Vector3(transform.position.x, transform.position.y, transform.position.z), Time.deltaTime/2);
    }
}
