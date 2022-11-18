using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]private string[] PossibleOrders;
    [SerializeField]private string currentOrder;
    void Start()
    {
        currentOrder = PossibleOrders[Random.Range(0, PossibleOrders.Length - 1)];
        CustomerScript.instance.AddRequest(currentOrder);
    }
}
