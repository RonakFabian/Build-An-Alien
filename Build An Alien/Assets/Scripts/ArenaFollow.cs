using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFollow : MonoBehaviour
{
    GameObject target;
    public ArenaTrigger arenaTrigger;
    private UnitMeshManager unit;
    private Unit unitNew;

    private void Start()
    {
        unit = FindObjectOfType<UnitMeshManager>();
    }

    void Update()
    {
        if (unit == null)
        {
            unit = FindObjectOfType<UnitMeshManager>();

            if (unit == null)
            {
                unitNew = FindObjectOfType<Unit>();
            }
        }

        if (unit)
            transform.position = unit.transform.position;
        else
        {
            if (unitNew)
                transform.position = unitNew.transform.position;

        }
    }
}