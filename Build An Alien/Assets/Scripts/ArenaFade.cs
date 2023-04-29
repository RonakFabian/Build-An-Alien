using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class ArenaFade : MonoBehaviour
{
    public Image panel;
    public float fadeOutDuration = 1.5f;
    private Sequence sequence;
    public GameObject camOne;
    public GameObject camTwo;

    void Start()
    {
        //  FadeIn();
    }

    void FadeOut()
    {
        sequence.Append(panel.DOFade(0, fadeOutDuration));
        sequence.Play();
    }

    public void FadeIn()
    {
        sequence = DOTween.Sequence();

        sequence.Append(panel.DOFade(1, .2f));
        sequence.Play();
        Invoke("FadeOut", fadeOutDuration);
        Invoke("SwitchCams", .5f);
    }

    void SwitchCams()
    {
        camOne.SetActive(false);
        camTwo.SetActive(true);
    }
}