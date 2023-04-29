using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeshManager : MonoBehaviour
{
    public SaveData saveData;
    public List<GameObject> legs = new List<GameObject>();
    public List<GameObject> torso = new List<GameObject>();
    public List<GameObject> head = new List<GameObject>();
    public Animator hAnim;
    public Animator tAnim;
    public Animator lAnim;

    private Unit unit;

    void Start()
    {
        DisableAll();
        head[saveData.HeadID].SetActive(true);
        hAnim = head[saveData.HeadID].GetComponent<Animator>();
        torso[saveData.TorsoID].SetActive(true);
        tAnim = torso[saveData.TorsoID].GetComponent<Animator>();
        legs[saveData.LegID].SetActive(true);
        lAnim = legs[saveData.LegID].GetComponent<Animator>();

        unit = GetComponent<Unit>();
        unit.lAnimator = lAnim;
        unit.tAnimator = tAnim;
        unit.hAnimator = hAnim;
        

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