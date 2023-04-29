using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Pawn> enemies;
  
    /*Has enemy pawns
     * Gets nearest enemy from list
     * Shoots and deals damage and checks
     * delete reference if zero
     * find next closest pawn from list
     */
    
    void Start()
    {
        StartFighting();
    }


 
 
    
    GameObject GetEnemy()
    {
        //return enemy not locked on
        return null;
    }

    public void StartFighting()
    {
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        
    }
    
}

