using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Pawn> pawns = new List<Pawn>();
    public int health = 0;
    public int damage = 0;
    public bool canAttack;

    private Pawn go;
    private LineRenderer lineRenderer;

    private void Start()
    {
        if (canAttack)
        {
            StartFighting();
        }
    }

    IEnumerator Shoot()
    {
        go = FindClosestTarget();
        print(go.name);
        if (lineRenderer)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, go.transform.position);
            if (go.TakeDamage(damage))
            {
                pawns.Remove(go);
                Destroy(go.gameObject);
            }

            yield return new WaitForSeconds(0.25f);
            lineRenderer.enabled = false;
        }
    }


    Pawn FindClosestTarget()
    {
        Vector3 position = transform.position;
        return pawns.OrderBy(o => (o.transform.position - position).sqrMagnitude)
            .FirstOrDefault();
    }

    void StartFighting()
    {
        StartCoroutine("RepeatShooting");
    }
    
    public  bool TakeDamage(int dmg)
    {
        health -= dmg;
        print("Taking damage");
        if (health <= 0)
        {

            return true;
        }

        return false;
    }
    
    IEnumerator RepeatShooting()
    {
        while (pawns.Count > 0)
        {
            yield return new WaitForSeconds(1);

            StartCoroutine("Shoot");
        }
    }
}