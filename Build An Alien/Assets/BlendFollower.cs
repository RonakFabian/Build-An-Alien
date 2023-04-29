using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendFollower : MonoBehaviour
{

    public Transform leader;
    public int count = 0;
    public float followSharpness = 0.05f;


    
    void Update()
    {
        if(leader)
             transform.position =Vector3.Lerp(transform.position, (leader.position+  Vector3.right* 1.3f), 12.5f*Time.deltaTime);

    }
}