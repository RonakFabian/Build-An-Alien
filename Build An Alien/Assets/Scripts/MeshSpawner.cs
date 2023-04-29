using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawner : MonoBehaviour
{
  public List<GameObject> headList;
  public List<GameObject> torsoList;
  public List<GameObject> legsList;

  public GameObject headTransfrom;
  public GameObject torsoTransfrom;
  public GameObject legTransfrom;

  public SaveData bodySaveData;
  private Player player;
  public List<Animator> animList;
  public LevelManager levelManager;
  void Start()
  {
    player = GetComponent<Player>();
  }

  void Update()
  {
    if (bodySaveData.isRunning)
    {
      bodySaveData.isRunning = false;
      Spawn();
      // player.OnStartRunning();
      Invoke("StartRunning", 1.4f);
      Invoke("PopUp", 0.35f);
      Invoke("SwtichCamera", 0.1f);

      levelManager.SetSkyboxSettings();
      player.Damage = bodySaveData.Damage;
      player.Health = bodySaveData.Health;


    }

  }

  void SwtichCamera()
  {
    player.SwitchCamera();

  }

  void PopUp()
  {
    player.gameObject.GetComponent<Animator>().Play("IdlePop");

  }
  void Spawn()
  {
    GameObject gO = Instantiate(headList[bodySaveData.HeadID], headTransfrom.gameObject.transform.position, Quaternion.Euler(Vector3.up * -80));
    gO.transform.SetParent(headTransfrom.transform);

    gO = Instantiate(torsoList[bodySaveData.TorsoID], torsoTransfrom.gameObject.transform.position, Quaternion.Euler(Vector3.up * -80));
    gO.transform.SetParent(torsoTransfrom.transform);

    gO = Instantiate(legsList[bodySaveData.LegID], legTransfrom.gameObject.transform.position, Quaternion.Euler(Vector3.up * -80));
    gO.transform.SetParent(legTransfrom.transform);
  }

  public void PlayAnims(bool b)
  {
    foreach (var a in animList)
    {
      a.SetBool("isRunning", b);
    }
  }

  void StartRunning()
  {
    player.OnStartRunning();

  }

}
