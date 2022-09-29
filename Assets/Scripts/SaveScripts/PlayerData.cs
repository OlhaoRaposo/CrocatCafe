using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "playerData",menuName = "INAT/Player Data")]
public class PlayerData : ScriptableObject
{
   public int coin;
   public string idObjects;
   public string[] idArray;
   public GameObject[] grid;

   public void LoadData(PlayerData data)
   {
      coin = data.coin;
      idObjects = data.idObjects;
      grid = data.grid;
   }
}