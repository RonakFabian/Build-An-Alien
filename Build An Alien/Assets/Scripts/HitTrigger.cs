using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public ParticleSystem ps;

    public void Emitt()
    {
        ps.Play();
    }
}
