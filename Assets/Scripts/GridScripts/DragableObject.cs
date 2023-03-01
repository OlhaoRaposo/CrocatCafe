using UnityEngine;

public class DragableObject : MonoBehaviour
{
    public GridCell currentCell = null, previousCell = null;
    private int myRotation;
    public Vector2 objectSize = new Vector2(1, 1);

    private void Start()
    {
        EditMode.instance.selectedObject = gameObject;
        EditMode.instance.UpdateLayers();
    }

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
        if (EditMode.instance.isEditing)
        {
            EditMode.instance.selectedObject = gameObject;
            EditMode.instance.UpdateLayers();
        }
    }

    private void OnMouseDrag() //é chamado quando movo o mouse
    {
        if (EditMode.instance.isEditing) //Está no edit mode?
        {
            EditMode.instance.UpdateLayers();
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
                        SnapObject();
                    }
                }
            }
        }
    }

    private void SnapObject()
    {

        transform.position = CalcSnap(); //snap
        currentCell.rotationValue = myRotation; //Coloca o valor de rotação na célula
        currentCell.currentObject = gameObject; //ocupa a célula nova
        currentCell.isOccupied = true;
    }

    private Vector3 CalcSnap()
    {
        Vector3 snapPos;
        snapPos = MouseRaycast.MousePos();

        float offsetX = 0, offsetZ = 0;
        offsetX = (objectSize.x / 2) - 0.5f;
        offsetZ = (objectSize.y / 2) - 0.5f;

        if(offsetX != 0 || offsetZ !=0)
        {
            GridSystem myGrid = CheckForCell().gameObject.transform.parent.gameObject.transform.parent.GetComponent<GridSystem>();
            if((float)CheckForCell().tilePos.x + offsetX < myGrid.sizeX)
            {
                snapPos.x += offsetX;
            }
            else
            {
                snapPos = transform.position;
            }
            if((float)CheckForCell().tilePos.y + offsetZ < myGrid.sizeZ)
            {
                snapPos.z += offsetZ;
            }
            else
            {
                snapPos = transform.position;
            }  
        }
        return snapPos;
    }

    public void Rotate() //Gira objeto
    {
        if (currentCell != null)
        {
            float x = objectSize.x, z = objectSize.y;
            objectSize.x = z; objectSize.y = x;
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
