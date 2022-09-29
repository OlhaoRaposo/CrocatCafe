using UnityEngine;

public class DragableObject : MonoBehaviour
{
    [SerializeField]private GridCell currentCell = null, previousCell = null;
    private GridCell CheckForCell() //Método que retorna a célula
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Cria um raio a partir da posição do mouse do player
        if(Physics.Raycast(mouseRay, out RaycastHit raycastHit) == true) //se o raycast criado pelo mouse atinge alguma coisa
        {
            return raycastHit.transform.gameObject.GetComponent<GridCell>(); //retorna o gridcell atingido pelo raycast
        }
        else
        {
            return null; //retorna nada se não atingir nada
        }
    }

    private void OnMouseDrag() //é chamado quando movo o mouse
    {
        if (MouseRaycast.MousePos() != Vector3.zero) //o mouse está atingindo uma célula do grid?
        {
            transform.position = MouseRaycast.MousePos(); //snap
            if(CheckForCell() != null) //checa a existência de uma célula
            {
                previousCell = currentCell; //cicla célula nova com a anterior
                currentCell = CheckForCell(); //pega a célula 
                if(previousCell != null) //exceção da existência de uma célula anterior, e esvazia a célula anterior
                {
                    previousCell.currentObject = null;
                    previousCell.isOccupied = false;
                }
                
                if(currentCell.isOccupied == false) //Checa se a célula já está ocupada
                {
                    currentCell.currentObject = gameObject; //ocupa a célula nova
                    currentCell.isOccupied = true;
                }
            }
        }
    }

    private void OnMouseUp() //Confirma a posição de um objeto (Serve para impedir 2 objetos no mesmo lugar)
    {
        if(currentCell != null)
        {
            transform.position = currentCell.transform.position; //Joga o objeto no último quadrado vazio pelo qual passou
        }
        else
        {
            Destroy(gameObject); //Se não conseguir jogar o objeto em lugar nenhum, ele só desiste e destrói o objeto
        }
    }

    public void Rotate() //Gira objeto
    {
        transform.Rotate(0, 90, 0);
    }
}
