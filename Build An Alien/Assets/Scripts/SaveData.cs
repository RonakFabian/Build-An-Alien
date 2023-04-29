using UnityEngine;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
   
   public int HeadID;
   public int TorsoID;
   public int LegID;
   
   public float Damage;
   public float Health;

   public bool isRunning = false;
   public int  playerCount;
   public bool isRanged;
}