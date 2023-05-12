using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endless : MonoBehaviour
{
  public float timer;
  public List<GameObject> Prefabs;

  float rateOfSpawn;
  float currentTime = 0;

  public float runnerTime = 100;

  public TMPro.TMP_Text scoreText;
  public TMPro.TMP_Text timerText;

  float score = 0;

  public enum PlanetEnum
  {
    Mars,
    Mercury,
    Venus,
    Jupiter,
    Saturn,
    Uranus,
    Neptune

  }

  PlanetEnum planet;

  void Start()
  {
    SpawnRandomly();
  }

  // Update is called once per frame
  void Update()
  {
    currentTime += Time.deltaTime;
    if (currentTime >= rateOfSpawn)
    {
      currentTime = 0;
      SpawnRandomly();
    }
    score += Time.fixedDeltaTime * 2f;
    scoreText.text = "Score:" + Mathf.RoundToInt(score);

    runnerTime -= Time.fixedDeltaTime * 0.25f;
    timerText.text = "Time To Reach Earth:" + Mathf.Floor(runnerTime / 60).ToString("00") + ":" + (runnerTime % 60).ToString("00");
    if (runnerTime <= 0)
    {
      SceneManager.LoadScene("MainGameplay");
    }
  }

  void SpawnRandomly()
  {

    rateOfSpawn = Random.Range(1, 2.5f);
    GameObject go = Instantiate(Prefabs[Random.Range(0, Prefabs.Count)], transform.position, transform.rotation);
    go.transform.SetParent(transform);
  }

  public void SetPlanet(int planet)
  {

  }

  public void StartGame()
  {

  }

  void SetPlanetDetails()
  {
    switch (planet)
    {
      case PlanetEnum.Mars:

        break;
    }
  }
}
