using System;
using System.Collections;
using DG.Tweening;
using Lofelt.NiceVibrations;
using TMPro;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public EMathFunctionType mathFunctionType;
    public int baseNumber;
    public TextMeshPro textMesh;
    private Player player;
    public Collider otherTrigger;
    private int modifiedNumber = 0;
    private int max = 1;
    IEnumerator c;
    public Transform autoMoveTransform;
    public MiddleModifier middleModifier;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
        SetText();

        if (player == null)
            Invoke("Find", 1f);
    }

    void Find()
    {
        player = FindObjectOfType<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knight"))
        {
            otherTrigger.enabled = false;
            if (middleModifier.isInMiddle)
            {
                player.StopPlayerInput();
                player.transform.DOMoveZ(autoMoveTransform.position.z, 0.7f).OnComplete(player.ResumePlayerInput);
            }
            
            // max = player.pawnSpawnPoint.childCount;
            max = player.playerPawns.Count;

            ModifyValues();
            HapticPatterns.PlayEmphasis(1.0f, 0.5f);

        }
    }

    void SetText()
    {
        switch (mathFunctionType)
        {
            case EMathFunctionType.Add:
                textMesh.text = "+" + baseNumber;
                break;

            case EMathFunctionType.Subtract:
                textMesh.text = "-" + baseNumber;
                break;

            case EMathFunctionType.Multiply:
                textMesh.text = "x" + baseNumber;
                break;

            case EMathFunctionType.Divide:
                textMesh.text = "÷" + baseNumber;
                break;
        }
    }

    void ModifyValues()
    {
        switch (mathFunctionType)
        {
            case EMathFunctionType.Add:
                //for (int i = 0; i < baseNumber; i++)
                //{
                //    StartCoroutine("Spawn");

                c = Spawn(baseNumber);
                StartCoroutine(c);

                //for (int i = 0; i < baseNumber; i++)
                //{
                //    StartCoroutine("Spawn");
                //}


                break;
            case EMathFunctionType.Subtract:
                player.StepBackCam();

                for (int i = 0; i < baseNumber; i++)
                {
                    player.DeletePawns();
                }

                break;
            case EMathFunctionType.Multiply:

                //for (int i = 0; i < ((max) * (baseNumber - 1)); i++)
                //{
                //   Invoke("Spawn", 0.25f);
                //}

                c = Spawn((max) * (baseNumber - 1));
                StartCoroutine(c);


                break;
            case EMathFunctionType.Divide:
                //  print("Before:" + player.pawnSpawnPoint.childCount);

                //print(Mathf.CeilToInt(max/baseNumber));
                // for (int i = player.playerPawns.Count; i < baseNumber-( max / (baseNumber)) - (max%2==0 ? 0 : 1) ; i--)
                player.StepBackCam();
                for (int i = max; i > (max / (baseNumber)); --i)
                {
                    // print(max + " /" + max / baseNumber + " i" + i);
                    player.DeletePawns();
                }
                // print("After:" + player.pawnSpawnPoint.childCount);



                break;
        }


    }

    IEnumerator Spawn(int i)
    {
        for (int j = 0; j < i; j++)
        {
            player.SpawnPawn();
            yield return new WaitForSeconds(0.2f);
        }

    }
}

public enum EMathFunctionType
{
    Add,
    Subtract,
    Multiply,
    Divide
}