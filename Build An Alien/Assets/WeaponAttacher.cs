using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttacher : MonoBehaviour
{
    public GameObject axe;
    public GameObject rifle;
    public SaveData saveData;

     void Start()
    {
        SetWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SetWeapon()
    {
        if(saveData.isRanged)
        {
            rifle.SetActive(true);
            axe.SetActive(false);
        }
        else
        {
            rifle.SetActive(false);
            axe.SetActive(true);
        }
    }
}
