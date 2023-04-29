using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    public int health;
    public int damage;
    public bool isMelee;
    public bool canAttack;
    
    private Enemy go;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        if(canAttack)
        StartAttacking();
    }

    /*Set Enemy List
     Find Closest
     Spawn Line trace, play anim?
     Set Ik to shoot
     Reposition
     */


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
                enemies.Remove(go);
                Destroy(go.gameObject);
            }

            yield return new WaitForSeconds(0.25f);
            lineRenderer.enabled = false;
        }
    }

    Enemy FindClosestTarget()
    {
        Vector3 position = transform.position;
        return enemies.OrderBy(o => (o.transform.position - position).sqrMagnitude)
            .FirstOrDefault();
    }

    public bool TakeDamage(int dmg)
    {
        health -= dmg;
        print("Taking damage");
        if (health <= 0)
        {
            return false;
        }

        return true;
    }

    IEnumerator RepeatShooting()
    {
        while (enemies.Count > 0)
        {
            yield return new WaitForSeconds(1);

            StartCoroutine("Shoot");
        }
    }

    public void StartAttacking()
    {
        StartCoroutine("RepeatShooting");
    }
}