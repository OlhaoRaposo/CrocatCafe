using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Armazen : MonoBehaviour
{
   public int massasAtual;
   public int massasMax = 40;
   public int breads;
   public int maxBreads;
   public Text breadstxt;
   public Text massastxt;

   public void AdicionaMassas(int quant)
   {
      if (massasAtual < massasMax) {
         massasAtual += quant;
         massastxt.text = "Massas: " +massasAtual;
      }
   }
   public void RemoveMassas(int quant)
   {
      if (massasAtual > 0) {
         massasAtual -= quant;
      }
      massastxt.text = "Massas: " +massasAtual;
   }
   public void AdicionaPao(int quant)
   {
      if (breads < maxBreads)
      {
         breads += quant;
      }
      breadstxt.text = "Breads: " + breads;
   }
}
