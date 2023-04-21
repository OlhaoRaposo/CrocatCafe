using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmazenAdapter : ArmazenData
{
   public ArmazenAdapter(ArmazenManager armazen)
   {
      moneydata = armazen.money;
      ingredientAmmount = armazen.ingredientAmmount;
      foodAmmount = armazen.foodAmmount;
   }
    
}
