using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Unit> targets;
    public Vector3 offset;
    public bool canFollow = true;
    private Bounds bounds;

    void Start()
    {
        //  GetAllUnits();
    }

    public void GetAllUnits()
    {
        Unit[] u = FindObjectsOfType<Unit>();
        print(u.Length);
        targets = u.ToList();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0) return;

        Vector3 centrePoint = GetCentrePoint();
        Vector3 newPosition = offset + centrePoint;
        transform.position = newPosition;
    }


    Vector3 GetCentrePoint()
    {
        if (canFollow)
        {
            if (targets.Count <= 1)
            {
                return targets.FirstOrDefault().transform.position;
            }

            bounds = new Bounds(targets[0].gameObject.transform.position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].gameObject.transform.position);
            }
            
        }
        return bounds.center;
    }
}