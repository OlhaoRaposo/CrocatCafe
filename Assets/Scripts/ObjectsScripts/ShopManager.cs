using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject armazen;
    [SerializeField]
    private int pageIndex = 1;
   public GameObject[] objects;
   public GameObject[] pages;

   private void Awake()
   {
       armazen = GameObject.Find("ArmazenManager");
       NextPage(0);
   }
   public void BuyObject(string code)
   {
      for (int i = 0; i < objects.Length; i++)
      {
          if (objects[i].GetComponent<ObjectScript>().objectId == code)
          {
              if (armazen.GetComponent<Armazen>().money >= objects[i].GetComponent<ObjectScript>().objectValue)
              {
                  armazen.GetComponent<Armazen>().money -= objects[i].GetComponent<ObjectScript>().objectValue;
                  Instantiate(objects[i], transform.position, quaternion.identity);
              }
          }
      }
   }
   public void NextPage(int page)
   {
       for (int i = 0; i < pages.Length; i++) 
       { 
           pages[i].SetActive(false);
       }
       if (pageIndex + page >= pages.Length) {
           pageIndex = 0;
       }else if (pageIndex + page < 0)
       {
           pageIndex = pages.Length-1;
       }
       else
           pageIndex += page;
       pages[pageIndex].SetActive(true);
   }
}
