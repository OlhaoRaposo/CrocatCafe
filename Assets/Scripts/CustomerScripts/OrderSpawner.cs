using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;

public class OrderSpawner : MonoBehaviour
{
    public GameObject head;
    public GameObject plate;
    public CustomerScript customerScript;
    public GameObject slots;

    public void AddPlate(FoodData order, GameObject customer)
    {
        //Adiciona o prato a uma lista duplamente encadiada
        GameObject plate = null;
        if (slots.GetComponent<SlotScript>().previousSlot.GetComponent<SlotScript>().alocatedPlate == null)
        {
            for (GameObject slot = slots; slot.GetComponent<SlotScript>().nextSlot != slot; slot = slot.GetComponent<SlotScript>().nextSlot)
            {
                if (slot.GetComponent<SlotScript>().alocatedPlate == null)
                {
                    //Instancia O prato 
                    plate = Instantiate(this.plate, slot.transform.position, quaternion.identity, slot.transform);
                    slot.GetComponent<SlotScript>().alocatedPlate = plate;
                    plate.GetComponent<plateData>().food = order;
                    //Aloca Referencias da lista duplamente encadiada
                    plate.GetComponent<plateData>().nextPlate = head.GetComponent<plateData>().nextPlate;
                    plate.GetComponent<plateData>().previousPlate = head;
                    plate.GetComponent<plateData>().nextPlate.gameObject.GetComponent<plateData>().previousPlate = plate;
                    head.GetComponent<plateData>().nextPlate = plate;

                    //Liga o consumidor com o prato em que ele pediu
                    customer.GetComponent<Customer>().order = plate.gameObject;
                    return;
                }
                else
                {
                    Console.WriteLine("EstaCheio");
                }
            }
        }
        else
            return;
        //====//
    }

    public void RemovePlate(GameObject plateToRemove)
    {
        for (GameObject plate = head.GetComponent<plateData>().nextPlate; plate != head; plate = plate.GetComponent<plateData>().nextPlate)
        {
            if (plate == plateToRemove)
            {
                plate.GetComponent<plateData>().previousPlate.gameObject.GetComponent<plateData>().nextPlate = plate.GetComponent<plateData>().nextPlate;
                plate.GetComponent<plateData>().nextPlate.GetComponent<plateData>().previousPlate = plate.GetComponent<plateData>().previousPlate;
                AttIcon(plate.transform.parent.gameObject, plate);
                AddCash(plate);
                return;
            }
        }
    }

    private void AttIcon(GameObject slotGmbj, GameObject plate)
    {
        for (GameObject slot = slotGmbj; slot.GetComponent<SlotScript>().nextSlot != slotGmbj; slot = slot.GetComponent<SlotScript>().nextSlot.gameObject)
        {
            Debug.Log(slot.name + "\n" + slot.name + "\n" + slot.GetComponent<SlotScript>().previousSlot.name + "\n" + slot.GetComponent<SlotScript>().nextSlot.name);
            if (slot.GetComponent<SlotScript>().nextSlot.gameObject.GetComponent<SlotScript>().alocatedPlate != null)
            {
                slot.GetComponent<SlotScript>().nextSlot.gameObject.GetComponent<SlotScript>().alocatedPlate.transform.position = slot.transform.position;
                slot.GetComponent<SlotScript>().nextSlot.gameObject.GetComponent<SlotScript>().alocatedPlate.transform.parent = slot.transform;
                slot.GetComponent<SlotScript>().alocatedPlate = slot.GetComponent<SlotScript>().nextSlot.gameObject.GetComponent<SlotScript>().alocatedPlate;
            }
            Destroy(plate);
        }

    }
    private void AddCash(GameObject plate)
    {
        ArmazenManager.instance.money += plate.GetComponent<plateData>().platePrice;
        ArmazenManager.instance.UpdateMoneyText();
    }
}
