using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class ArenaTrigger : MonoBehaviour
{
    public Player player;
    public ArenaFade arenaFade;
    public GameObject spawnedPawnsParent;
    public SaveData saveData;

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;

    public GameObject placeToSpawn;
    public CharacterPlacement characterPlacement;
    public List<GameObject> spawnedAllies = new List<GameObject>();
    public EnemyArmy enemyArmy;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Knight"))
        {
            if (player)
            {
                player.ArenaReached();
                arenaFade.FadeIn();
                Invoke("StartArena", 0.3f);
                saveData.playerCount = player.playerPawns.Count;

            }
        }
    }

    void StartArena()
    {
        print("Started");
        player.DeleteAllRunnerAllies();
        //  saveData.playerCount = player.playerPawns.Count;
        if (saveData.isRanged)
        {
            meleeEnemy = rangedEnemy;
        }

        print(player.playerPawns.Count);
        int x=0;//10  5
        //  int x =0, y = 0;

        if (player.playerPawns.Count > 2)
        {
            for (int a = 0; a < 3; a++)
            {

                for (int j = 0; j <= player.playerPawns.Count / 3; j++)
                {
                    GameObject go = Instantiate(meleeEnemy, placeToSpawn.transform.position, Quaternion.identity);
                    go.transform.SetParent(placeToSpawn.transform);
                    go.transform.localPosition += Vector3.right * (a * 4f);
                    go.transform.localPosition -= Vector3.forward * (j * 4f);
                    spawnedAllies.Add(go);

                }
                x = player.playerPawns.Count / 3;

            }
        }
        else
        {

          

                for (int j = 0; j <= player.playerPawns.Count; j++)
                {
                    GameObject go = Instantiate(meleeEnemy, placeToSpawn.transform.position, Quaternion.identity);
                    go.transform.SetParent(placeToSpawn.transform);
                  //  go.transform.localPosition += Vector3.right * (a * 4f);
                    go.transform.localPosition -= Vector3.forward * (j * 4f);
                    spawnedAllies.Add(go);

                }
              
        }

        print(spawnedAllies.Count);










        //for (int j = 0; j < saveData.playerCount; j++)
        //{
        //    y++;
        //    if (y > 3)
        //    {
        //        y = 1;
        //        x++;

        //        x = (player.playerPawns.Count - 1) / 3;
        //        GameObject go = Instantiate(meleeEnemy, placeToSpawn.transform.position, Quaternion.identity);
        //        go.transform.SetParent(placeToSpawn.transform);
        //        go.transform.localPosition += Vector3.right * (x * 4f);
        //        go.transform.localPosition -= Vector3.forward * (y * 4f);
        //        spawnedAllies.Add(go);

        //    }



        Invoke("StartBattle",1);
        
    } 

    void StartBattle()
    {
        
        foreach (var spawnedAlly in spawnedAllies)
        {
            spawnedAlly.GetComponent<Unit>().enabled = true;
            spawnedAlly.GetComponent<NavMeshAgent>().enabled = true;
        }
        characterPlacement.startBattle();
        Destroy(player.gameObject);
    }
}