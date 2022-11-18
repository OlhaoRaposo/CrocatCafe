using UnityEngine;

public class DragableObject : MonoBehaviour
{
    [SerializeField] private GridCell currentCell = null, previousCell = null;
    private int myRotation;
    private GridCell CheckForCell() //Método que retorna a célula
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Cria um raio a partir da posição do mouse do player
        if (Physics.Raycast(mouseRay, out RaycastHit raycastHit) == true) //se o raycast criado pelo mouse atinge alguma coisa
        {
            return raycastHit.transform.gameObject.GetComponent<GridCell>(); //retorna o gridcell atingido pelo raycast
        }
        else
        {
            return null; //retorna nada se não atingir nada
        }
    }

    private void OnMouseDown()
    {
        EditMode.SelectedObject = gameObject;
    }

    private void OnMouseDrag() //é chamado quando movo o mouse
    {
        if (EditMode.isEditing) //Está no edit mode?
        {
            if (CheckForCell() != null) //checa a existência de uma célula
            {
                if (gameObject.layer == CheckForCell().gameObject.layer) //Só da snap se a layer for a mesma do objeto.
                {
                    previousCell = currentCell; //cicla célula nova com a anterior
                    currentCell = CheckForCell(); //pega a célula 
                    if (previousCell != null) //exceção da existência de uma célula anterior, e esvazia a célula anterior
                    {
                        previousCell.rotationValue = 0;
                        previousCell.currentObject = null;
                        previousCell.isOccupied = false;
                    }

                    if (currentCell.isOccupied == false) //Checa se a célula já está ocupada
                    {
                        transform.position = MouseRaycast.MousePos(); //snap
                        currentCell.rotationValue = myRotation; //Coloca o valor de rotação na célula
                        currentCell.currentObject = gameObject; //ocupa a célula nova
                        currentCell.isOccupied = true;
                    }
                }
            }
            else
            {
                /*Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit raycastHit) == true)
                {
                    Vector3 pos = raycastHit.point;
                    pos.y = 0;
                    transform.position = pos;
                } */
            }
        }
    }

    public void Rotate() //Gira objeto
    {
        if (currentCell != null)
        {
            transform.Rotate(0, 90, 0);
            if (myRotation < 3)
            {
                myRotation++;
            }
            else
            {
                myRotation = 0;
            }
            currentCell.rotationValue = myRotation;
        }
    }

    public void Remove() //Tira o objeto da cena.
    {
        if (currentCell != null)
        {
            currentCell.rotationValue = 0;
            currentCell.isOccupied = false;
            currentCell.currentObject = null;
        }
        Destroy(gameObject);
    }
}
