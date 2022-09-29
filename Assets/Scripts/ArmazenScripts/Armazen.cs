using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Armazen : MonoBehaviour
{
   public int massasAtual;
   public int massasMax = 40;
   public Text itens;
   
   
   public void AdicionaMaterial(int quant)
   {
      if (massasAtual < massasMax) {
         massasAtual += quant;
         itens.text = "Massas: " +massasAtual.ToString();
      }
   }
   public void RemoveMaterial(int quant)
   {
      if (massasAtual > 0) {
         massasAtual -= quant;
      }
   }
}
