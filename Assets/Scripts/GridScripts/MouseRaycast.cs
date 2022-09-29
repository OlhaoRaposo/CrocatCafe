using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    public static Vector3 MousePos() //Método que retorna a posição do mouse
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Cria um raio a partir da posição do mouse do player
        if(Physics.Raycast(mouseRay, out RaycastHit raycastHit) == true) //se o raycast criado pelo mouse atinge alguma coisa
        {
            return raycastHit.transform.position; //retorna onde o raycast criado pelo mouse atingiu
        }
        else
        {
            return Vector3.zero; //retorna zero se não atingir nada
        }
    }
}
