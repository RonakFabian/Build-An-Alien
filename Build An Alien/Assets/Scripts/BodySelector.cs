using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BodySelector : MonoBehaviour
{
    public List<GameObject> HeadPrefabs;
    public List<GameObject> TorsoPrefabs;
    public List<GameObject> LegPrefabs;

    public List<GameObject> spawnedHeads;
    public List<GameObject> spawnedTorsos;
    public List<GameObject> spawnedLegs;


    public List<Button> arrowButtons;


    public GameObject headTransform;
    public GameObject torsoTransform;
    public GameObject legsTransform;

    public SaveData bodySaveData;
    public TMP_Text healthText;
    public TMP_Text damageText;

    private int headIndex = 0;
    private int torsoIndex = 0;
    private int legsIndex = 0;

    private bool isMelee = true;
    public Image weaponImg;
    public Sprite meleeSprite;
    public Sprite rangedSprite;


    private List<int> selectedNumbers;
    private List<int> unlockedNumbers;

    public GameObject headLock;
    public GameObject torsoLock;
    public GameObject legLock;
    public GameObject weaponLock;
    public GameObject readyBtn;
    private int maxUnlock = 0;
    private bool weaponUnlocked = false;

    public Animator uiAnim;

    public GameObject headParticle;
    public GameObject torsoarticle;
    public GameObject legParticle;

    int h = 0;
    int t = 0;
    int l = 0;

    void Start()
    {
        selectedNumbers = new List<int>();
        selectedNumbers.Add(0);
        selectedNumbers.Add(0);
        selectedNumbers.Add(0);

        unlockedNumbers = new List<int>();
        unlockedNumbers.Add(0);
        unlockedNumbers.Add(1);
        unlockedNumbers.Add(2);


        SpawnAllParts();

        SelectHead();
        SelectTorso();
        SelectLegs();
        SetAttributes();

        if (isMelee)
        {
            weaponImg.sprite = meleeSprite;
            bodySaveData.isRanged = false;
        }
        else
        {
            weaponImg.sprite = rangedSprite;
            bodySaveData.isRanged = true;
        }

        Time.timeScale = 1;
        maxUnlock = PlayerPrefs.GetInt("MaxUnlock");
        print(maxUnlock);
        if (maxUnlock == 1)
        {
            //weapon unlock
            weaponUnlocked = true;
            unlockedNumbers.Add(3);
        }

        if (maxUnlock == 2)
        {
            weaponUnlocked = true;
            unlockedNumbers.Add(4);
        }

        if (maxUnlock == 3)
        {
            weaponUnlocked = true;
            unlockedNumbers.Add(5);
        }

        CheckIfUnlocked();
        ResetTaunt();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     IncreaseUnlockLevel();
        //     print(maxUnlock);
        // }
    }




    IEnumerator HeadSwap()
    {
        yield return new WaitForSeconds(0.25f);
        DisableAllMeshes(spawnedHeads);
        yield return new WaitForSeconds(0.25f);
        spawnedHeads[headIndex].transform.position = new Vector3(spawnedHeads[headIndex].transform.position.x, 15f, spawnedHeads[headIndex].transform.position.z);

        foreach (var b in arrowButtons)
        {
            b.interactable = true;
        }

        spawnedHeads[headIndex].SetActive(true);
        spawnedHeads[headIndex].transform.DOMove(new Vector3(70.18f, 2.96f, 8.25f), 0.1f);

        yield return new WaitForSeconds(0.1f);
        headParticle.SetActive(true);


        ResetAnimations();
        Invoke("PlayTauntAnims", 0.2f);

    }
    IEnumerator TorsoSwap()
    {
        yield return new WaitForSeconds(0.25f);
        DisableAllMeshes(spawnedTorsos);
        yield return new WaitForSeconds(0.25f);
        spawnedTorsos[torsoIndex].transform.position = new Vector3(63, spawnedTorsos[torsoIndex].transform.position.y, 1.25f);
        //originalpos
        spawnedTorsos[torsoIndex].SetActive(true);
        spawnedTorsos[torsoIndex].transform.DOMove(new Vector3(70.18f, 2.96f, 8.25f), 0.1f);

        foreach (var b in arrowButtons)
        {
            b.interactable = true;
        }
        yield return new WaitForSeconds(0.1f);
        torsoarticle.SetActive(true);


        ResetAnimations();
        Invoke("PlayTauntAnims", 0.2f);

    }
    IEnumerator LegSwap()
    {

        yield return new WaitForSeconds(0.5f);
        DisableAllMeshes(spawnedLegs);
        yield return new WaitForSeconds(0.25f);

        spawnedLegs[legsIndex].transform.position = new Vector3(spawnedLegs[legsIndex].transform.position.x, -15f, spawnedLegs[legsIndex].transform.position.z);

        spawnedLegs[legsIndex].SetActive(true);
        spawnedLegs[legsIndex].transform.DOMove(new Vector3(70.18f, 2.96f, 8.25f), 0.1f);

        foreach (var b in arrowButtons)
        {
            b.interactable = true;
        }
        yield return new WaitForSeconds(0.1f);
        legParticle.SetActive(true);

        ResetAnimations();
        Invoke("PlayTauntAnims", 0.2f);
    }

    public void SelectHead(int i)
    {
        uiAnim.Play("UI Pullin");
        h = headIndex;
        foreach (var b in arrowButtons)
        {
            b.interactable = false;
        }
        headIndex += i;

        if (headIndex < 0)
        {
            headIndex = spawnedHeads.Count - 1;
        }
        else if (headIndex > spawnedHeads.Count - 1)
        {
            headIndex = 0;
        }


        Invoke("HeadMove", 0.25f);
        SetAttributes();
        selectedNumbers[0] = headIndex;
        headLock.SetActive(selectedNumbers[0] > unlockedNumbers.Max());

        switch (headIndex)
        {
            case 3:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 3";
                break;
            case 4:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
            case 5:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 6";
                break;
        }

        CheckIfUnlocked();
    }
    public void SelectHead()
    {


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
        ResetAnimations();
        SetAttributes();
        selectedNumbers[0] = headIndex;
        headLock.SetActive(selectedNumbers[0] > unlockedNumbers.Max());

        switch (headIndex)
        {
            case 3:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 3";
                break;
            case 4:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
            case 5:
                headLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 6";
                break;
        }

        CheckIfUnlocked();
    }
    public void SelectTorso(int i)
    {
        uiAnim.Play("UI Pullin");
        t = torsoIndex;
        foreach (var b in arrowButtons)
        {
            b.interactable = false;
        }
        torsoIndex += i;

        if (torsoIndex < 0)
        {
            torsoIndex = spawnedTorsos.Count - 1;
        }
        else if (torsoIndex > spawnedTorsos.Count - 1)
        {
            torsoIndex = 0;
        }


        Invoke("TorsoMove", 0.25f);

        SetAttributes();
        selectedNumbers[1] = torsoIndex;

        torsoLock.SetActive(selectedNumbers[1] > unlockedNumbers.Max());
        switch (torsoIndex)
        {
            case 3:
                torsoLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
        }

        CheckIfUnlocked();
    }
    public void SelectTorso()
    {
        //torsoIndex += i;

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
        ResetAnimations();
        SetAttributes();
        selectedNumbers[1] = torsoIndex;

        torsoLock.SetActive(selectedNumbers[1] > unlockedNumbers.Max());
        switch (torsoIndex)
        {
            case 3:
                torsoLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
        }

        CheckIfUnlocked();
    }

    public void SelectLegs(int i)
    {
        uiAnim.Play("UI Pullin");
        l = legsIndex;

        foreach (var b in arrowButtons)
        {
            b.interactable = false;
        }
        legsIndex += i;

        if (legsIndex < 0)
        {
            legsIndex = spawnedLegs.Count - 1;
        }
        else if (legsIndex > spawnedLegs.Count - 1)
        {
            legsIndex = 0;
        }


        Invoke("LegsMove", 0.25f);

        SetAttributes();
        selectedNumbers[2] = legsIndex;

        legLock.SetActive(selectedNumbers[2] > unlockedNumbers.Max());

        switch (legsIndex)
        {
            case 3:
                legLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
        }

        CheckIfUnlocked();
    }
    public void SelectLegs()
    {
        // legsIndex += i;

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
        ResetAnimations();
        SetAttributes();
        selectedNumbers[2] = legsIndex;

        legLock.SetActive(selectedNumbers[2] > unlockedNumbers.Max());

        switch (legsIndex)
        {
            case 3:
                legLock.GetComponentInChildren<TMP_Text>().text = "Unlocks at Level 5";
                break;
        }

        CheckIfUnlocked();
    }

    void HeadMove()
    {
        spawnedHeads[h].SetActive(true);
        spawnedHeads[h].transform.DOMove(new Vector3(spawnedHeads[headIndex].transform.position.x, 15f, spawnedHeads[headIndex].transform.position.z), 0.25f);
        StopCoroutine(HeadSwap());
        StartCoroutine(HeadSwap());
    }

    void TorsoMove()
    {
        spawnedTorsos[t].SetActive(true);
        spawnedTorsos[t].transform.DOMove(new Vector3(62.5f, spawnedTorsos[torsoIndex].transform.position.y, 1.2f), 0.25f);
        StopCoroutine(TorsoSwap());
        StartCoroutine(TorsoSwap());

    }
    void LegsMove()
    {
        spawnedLegs[l].SetActive(true);
        spawnedLegs[l].transform.DOMove(new Vector3(spawnedLegs[legsIndex].transform.position.x, -15f, spawnedLegs[legsIndex].transform.position.z), 0.25f);
        StopCoroutine(LegSwap());
        StartCoroutine(LegSwap());

    }
    public void SaveSelection()
    {
        bodySaveData.HeadID = spawnedHeads[headIndex].GetComponent<BodyPart>().ID;
        bodySaveData.TorsoID = spawnedTorsos[torsoIndex].GetComponent<BodyPart>().ID;
        bodySaveData.LegID = spawnedLegs[legsIndex].GetComponent<BodyPart>().ID;
        bodySaveData.isRunning = true;
    }

    void DisableAllMeshes(List<GameObject> pool)
    {
        foreach (var g in pool)
        {
            g.SetActive(false);
        }
    }


    void SpawnAllParts()
    {
        foreach (var part in HeadPrefabs)
        {
            GameObject gO = Instantiate(part, headTransform.gameObject.transform.position,
                Quaternion.Euler(Vector3.up * -110));
            gO.SetActive(false);
            gO.transform.localScale *= 2.25f;
            spawnedHeads.Add(gO);
            gO.transform.SetParent(headTransform.transform);
        }

        foreach (var part in TorsoPrefabs)
        {
            GameObject gO = Instantiate(part, torsoTransform.gameObject.transform.position,
                Quaternion.Euler(Vector3.up * -110));
            gO.SetActive(false);
            gO.transform.localScale *= 2.25f;
            spawnedTorsos.Add(gO);
            gO.transform.SetParent(torsoTransform.transform);
        }

        foreach (var part in LegPrefabs)
        {
            GameObject gO = Instantiate(part, legsTransform.gameObject.transform.position,
                Quaternion.Euler(Vector3.up * -110));
            gO.SetActive(false);
            gO.transform.localScale *= 2.25f;
            spawnedLegs.Add(gO);
            gO.transform.SetParent(legsTransform.transform);
        }
    }

    void ResetAnimations()
    {
        //spawnedHeads[headIndex].GetComponent<Animator>().Play("Idle", 0, 0);
        //spawnedTorsos[torsoIndex].GetComponent<Animator>().Play("Idle", 0, 0);
        //spawnedLegs[legsIndex].GetComponent<Animator>().Play("Idle", 0, 0);

        spawnedHeads[headIndex].GetComponent<Animator>().SetBool("Pose", false);
        spawnedTorsos[torsoIndex].GetComponent<Animator>().SetBool("Pose", false);
        spawnedLegs[legsIndex].GetComponent<Animator>().SetBool("Pose", false);

        Invoke("Pullback", 1f);



    }

    void Pullback()
    {
        uiAnim.Play("UI Pullback");
    }

    void ResetTaunt()
    {
        //spawnedHeads[headIndex].GetComponent<Animator>().SetInteger("Taunt", 0);
        //spawnedTorsos[torsoIndex].GetComponent<Animator>().SetInteger("Taunt", 0);
        //spawnedLegs[legsIndex].GetComponent<Animator>().SetInteger("Taunt", 0);
    }

    void PlayPoseAnim()
    {
        //spawnedHeads[headIndex].GetComponent<Animator>().SetBool("Pose", true);
        //spawnedTorsos[torsoIndex].GetComponent<Animator>().SetBool("Pose", true);
        //spawnedLegs[legsIndex].GetComponent<Animator>().SetBool("Pose", true);
        //uiAnim.Play("UI Pullin");
    }

    void PlayTauntAnims()
    {
         int i = UnityEngine.Random.Range(0, 3);

        switch (i)
        {
            case 0:
                spawnedHeads[headIndex].GetComponent<Animator>().SetTrigger("TauntOne");
                spawnedTorsos[torsoIndex].GetComponent<Animator>().SetTrigger("TauntOne");
                spawnedLegs[legsIndex].GetComponent<Animator>().SetTrigger("TauntOne");
                break;
            case 1:
                spawnedHeads[headIndex].GetComponent<Animator>().SetTrigger("TauntTwo");
                spawnedTorsos[torsoIndex].GetComponent<Animator>().SetTrigger("TauntTwo");
                spawnedLegs[legsIndex].GetComponent<Animator>().SetTrigger("TauntTwo");
                break;

            case 2:
                spawnedHeads[headIndex].GetComponent<Animator>().SetTrigger("TauntThree");
                spawnedTorsos[torsoIndex].GetComponent<Animator>().SetTrigger("TauntThree");
                spawnedLegs[legsIndex].GetComponent<Animator>().SetTrigger("TauntThree");
                break;
        }


    }

    public void SetAttributes()
    {
        bodySaveData.Damage = spawnedHeads[headIndex].GetComponent<BodyPart>().Damage +
                              spawnedTorsos[torsoIndex].GetComponent<BodyPart>().Damage +
                              spawnedLegs[legsIndex].GetComponent<BodyPart>().Damage;
        damageText.text = "Attack : " + bodySaveData.Damage.ToString();

        bodySaveData.Health = spawnedHeads[headIndex].GetComponent<BodyPart>().Health +
                              spawnedTorsos[torsoIndex].GetComponent<BodyPart>().Health +
                              spawnedLegs[legsIndex].GetComponent<BodyPart>().Health;
        healthText.text = "Health : " + bodySaveData.Health.ToString();
    }

    public void ToggleWeaponType()
    {
        isMelee = !isMelee;
        if (isMelee)
        {
            weaponImg.sprite = meleeSprite;
            bodySaveData.isRanged = false;
            weaponLock.SetActive(false);
            PlayAxe();
        }
        else
        {
            weaponImg.sprite = rangedSprite;
            bodySaveData.isRanged = true;

            if (weaponUnlocked)
                weaponLock.SetActive(false);
            else
            {
                weaponLock.SetActive(true);
            }
            PlayGun();
        }

        spawnedTorsos[torsoIndex].GetComponent<WeaponAttacher>().SetWeapon();


        CheckIfUnlocked();
    }

    void PlayAxe()
    {
        spawnedHeads[headIndex].GetComponent<Animator>().SetTrigger("Axe");
        spawnedTorsos[torsoIndex].GetComponent<Animator>().SetTrigger("Axe");
        spawnedLegs[legsIndex].GetComponent<Animator>().SetTrigger("Axe");
    }

    void PlayGun()
    {
        spawnedHeads[headIndex].GetComponent<Animator>().SetTrigger("Gun");
        spawnedTorsos[torsoIndex].GetComponent<Animator>().SetTrigger("Gun");
        spawnedLegs[legsIndex].GetComponent<Animator>().SetTrigger("Gun");
    }

    void CheckIfUnlocked()
    {
        if (headLock.activeInHierarchy || torsoLock.activeInHierarchy || legLock.activeInHierarchy ||
            weaponLock.activeInHierarchy)
        {
            readyBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            readyBtn.GetComponent<Button>().interactable = true;
        }
    }

    public void IncreaseUnlockLevel()
    {
        maxUnlock++;
        PlayerPrefs.SetInt("MaxUnlock", maxUnlock);
    }
}