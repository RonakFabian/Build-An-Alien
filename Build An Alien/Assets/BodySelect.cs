using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodySelect : MonoBehaviour
{

  public List<GameObject> spawnedHeads;
  public List<GameObject> spawnedTorsos;
  public List<GameObject> spawnedHands;
  public List<GameObject> spawnedLegs;




  public GameObject headTransform;
  public GameObject torsoTransform;
  public GameObject handsTransform;
  public GameObject legsTransform;

  private int headIndex = 0;
  private int torsoIndex = 0;
  private int legsIndex = 0;
  private int handsIndex = 0;

  private GameObject currentHead;
  private GameObject currentHands;
  private GameObject currentLegs;
  private GameObject currentTorso;
  void Start()
  {
    DisableAllMeshes(spawnedHeads);
    DisableAllMeshes(spawnedHands);
    DisableAllMeshes(spawnedTorsos);
    DisableAllMeshes(spawnedLegs);

    spawnedHeads[0].SetActive(true);
    spawnedHands[0].SetActive(true);
    spawnedTorsos[0].SetActive(true);
    spawnedLegs[0].SetActive(true);

    currentHead = spawnedHeads[0];
    currentHands = spawnedHands[0];
    currentTorso = spawnedTorsos[0];
    currentLegs = spawnedLegs[0];

  }

  // Update is called once per frame
  void Update()
  {

  }



  void DisableAllMeshes(List<GameObject> pool)
  {
    foreach (var g in pool)
    {
      g.SetActive(false);
    }
  }

  public void SelectHead(int i)
  {
    headIndex += i;

    if (headIndex < 0)
    {
      headIndex = spawnedHeads.Count - 1;
    }
    else if (headIndex > spawnedHeads.Count - 1)
    {
      headIndex = 0;
    }

    DisableAllMeshes(spawnedHeads);
    spawnedHeads[headIndex].SetActive(true);
    currentHead = spawnedHeads[headIndex];
    ResetAnimations();
  }

  public void SelectLegs(int i)
  {
    legsIndex += i;

    if (legsIndex < 0)
    {
      legsIndex = spawnedLegs.Count - 1;
    }
    else if (legsIndex > spawnedLegs.Count - 1)
    {
      legsIndex = 0;
    }

    DisableAllMeshes(spawnedLegs);
    spawnedLegs[legsIndex].SetActive(true);
    currentLegs = spawnedLegs[legsIndex];
    ResetAnimations();
  }
  public void SelectTorso(int i)
  {
    torsoIndex += i;

    if (torsoIndex < 0)
    {
      torsoIndex = spawnedTorsos.Count - 1;
    }
    else if (torsoIndex > spawnedTorsos.Count - 1)
    {
      torsoIndex = 0;
    }

    DisableAllMeshes(spawnedTorsos);
    spawnedTorsos[torsoIndex].SetActive(true);
    currentTorso = spawnedTorsos[torsoIndex];
    ResetAnimations();
  }
  public void SelectHands(int i)
  {
    handsIndex += i;

    if (handsIndex < 0)
    {
      handsIndex = spawnedHands.Count - 1;
    }
    else if (handsIndex > spawnedHands.Count - 1)
    {
      handsIndex = 0;
    }

    DisableAllMeshes(spawnedHands);
    spawnedHands[handsIndex].SetActive(true);
    currentHands = spawnedHands[handsIndex];
    ResetAnimations();
  }

  void ResetAnimations()
  {
    currentHead.GetComponent<Animator>().Play("Alien_Idle", 0, 0);
    currentHands.GetComponent<Animator>().Play("Alien_Idle", 0, 0);
    currentLegs.GetComponent<Animator>().Play("Alien_Idle", 0, 0);
    currentTorso.GetComponent<Animator>().Play("Alien_Idle", 0, 0);

    //Alien_Flip
  }


}
