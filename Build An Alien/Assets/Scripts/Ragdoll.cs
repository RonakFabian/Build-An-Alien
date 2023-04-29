using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Ragdoll : MonoBehaviour
{
    public List<GameObject> legs = new List<GameObject>();
    public List<GameObject> torso = new List<GameObject>();
    public List<GameObject> head = new List<GameObject>();

    public MeleeRagdoll MeleeRagdollData;
    public SaveData SaveData;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
       
    }

    void DisableAll()
    {
        foreach (var g in legs)
        {
            g.SetActive(false);
        }

        foreach (var g in torso)
        {
            g.SetActive(false);
        }

        foreach (var g in head)
        {
            g.SetActive(false);
        }
    }

    public void SetEnemyMesh()
    {
        DisableAll();

        head[MeleeRagdollData.HeadID].SetActive(true);
        torso[MeleeRagdollData.TorsoID ].SetActive(true);
        legs[MeleeRagdollData.LegID ].SetActive(true);
        print("SetEnemyMesh:"+MeleeRagdollData.HeadID);
        StartCoroutine(KnockBack());
    }

    public void SetAllyMesh()
    {
        DisableAll();
        print("SetAllyMesh");
        head[SaveData.HeadID].SetActive(true);
        torso[SaveData.TorsoID].SetActive(true);
        legs[SaveData.LegID].SetActive(true);
        print("SetAllyMesh:"+SaveData.HeadID);

        StartCoroutine(KnockBack());
    }

    IEnumerator KnockBack()
    {
        print("KnockBack");
        if (rb)
            rb.AddForce(-transform.forward * Random.Range(25, 45)+(transform.right*Random.Range(-25,25)), ForceMode.Impulse);
        yield return new WaitForSeconds(2.5f);
        if (rb)
            rb.velocity = Vector3.zero;
    }

    public void SetPawnMesh()
    {
        DisableAll();
        head[SaveData.HeadID].SetActive(true);
        torso[SaveData.TorsoID].SetActive(true);
        legs[SaveData.LegID].SetActive(true);

        head[SaveData.HeadID].GetComponent<Animator>().Play("Standing React Death Forward");
        torso[SaveData.TorsoID].GetComponent<Animator>().Play("Standing React Death Forward");
        legs[SaveData.LegID].GetComponent<Animator>().Play("Standing React Death Forward");
    }
}