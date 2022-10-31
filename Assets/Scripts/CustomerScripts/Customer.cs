using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]private string currentOrder;
    void Start()
    {
        //Puxar lista de receitas disponíveis
        Debug.Log("Pedido ativo");
    }
}
