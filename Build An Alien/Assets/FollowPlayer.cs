using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public GameObject sphere;
    public GameObject player;


    void Start()
    {
      
        SpawnTransforms();
    }

    void Update()
    {

        Vector3 point =  player.transform.position - targets[0].transform.position ;
        point.Normalize();
        transform.position = player.transform.position+Vector3.forward * (-1 * 2.6f);

    }

    void SpawnTransforms()
    {
        for(int i =0; i<10;i++)
        {
            GameObject go = Instantiate(sphere, transform.position +( Vector3.right * i*1.3f) + Vector3.forward * (-1 * 2.6f), Quaternion.identity);
            go.GetComponent<BlendFollower>().count=i;
            targets.Add(go);

            if (i == 0)
            {
                go.GetComponent<BlendFollower>().leader = this.transform;
            }
            else
            {
                go.GetComponent<BlendFollower>().leader = targets[i - 1].gameObject.transform;
            }

         

        }
    }
}
