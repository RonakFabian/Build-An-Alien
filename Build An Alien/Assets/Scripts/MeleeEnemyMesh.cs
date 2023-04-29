using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    Bear,
    Tiger,
    Moose,
    Crocodile,
    Elephant,
    Boar
}

public class MeleeEnemyMesh : MonoBehaviour
{
    public BodyType headType;
    public BodyType torsoType;
    public BodyType legType;
    public List<GameObject> legs = new List<GameObject>();
    public List<GameObject> torso = new List<GameObject>();
    public List<GameObject> head = new List<GameObject>();
    public Animator hAnim;
    public Animator tAnim;
    public Animator lAnim;

    private Unit unit;
    public MeleeRagdoll MeleeRagdollData;

    void Start()
    {
        DisableAll();
        head[(int)headType].SetActive(true);
        hAnim = head[(int)headType].GetComponent<Animator>();
        torso[(int)torsoType].SetActive(true);
        tAnim = torso[(int)torsoType].GetComponent<Animator>();
        legs[(int)legType].SetActive(true);
        lAnim = legs[(int)legType].GetComponent<Animator>();

        unit = GetComponent<Unit>();
        if (unit)
        {
            unit.lAnimator = lAnim;
            unit.tAnimator = tAnim;
            unit.hAnimator = hAnim;
        }

        MeleeRagdollData.HeadID = (int) headType;
        MeleeRagdollData.TorsoID = (int) torsoType;
        MeleeRagdollData.LegID = (int) legType;
        
//        print( MeleeRagdollData.HeadID);
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

  
}

