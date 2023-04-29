using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image panel;
    public float fadeOutDuration = 1.5f;
    private Sequence sequence;
    private bool canFade = true;

 

    public void FadeOutBlack()
    {
        canFade = false;
        sequence = DOTween.Sequence();
        sequence.Append(panel.DOFade(0.0f, fadeOutDuration));
        sequence.Play();
       
    }

   

    public void FadeIn()
    {
        sequence = DOTween.Sequence();
        sequence.Append(panel.DOFade(1f, .1f));
        sequence.Play();
        Invoke("StartPlaying",0.6f);
    }



    void StartPlaying()
    {
        sequence = DOTween.Sequence();
        sequence.Append(panel.DOFade(0f, 0.25f));
        sequence.Play();
    }

}