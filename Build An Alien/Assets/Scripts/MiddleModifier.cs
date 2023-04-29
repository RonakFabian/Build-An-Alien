using UnityEngine;

public class MiddleModifier : MonoBehaviour
{
    public bool isInMiddle;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knight")) isInMiddle = true;
    }
}