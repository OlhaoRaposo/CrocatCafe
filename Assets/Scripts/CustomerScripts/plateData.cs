using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plateData : MonoBehaviour
{
 public FoodData food;
 public int platePrice;
 public Image myImage;

 public GameObject nextPlate;
 public GameObject previousPlate;

 public void Start()
 {
    if(myImage != null)
    {
        myImage.sprite = food.icon;
    }
 }

}
