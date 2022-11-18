using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField]private string myLayer;
    [SerializeField]private float sizeX, sizeZ;
    [SerializeField]private Vector3 gridHead;
    [SerializeField]private GameObject grid, gridCell;
    public static GridCell currentSelectedCell;
    private bool isGridEnabled;
    
    private void Start()
    {
        InitGrid(); //Carrega todos as células de grid
    }

    private void InitGrid()
    {
        Vector3 pos = gridHead; //posição na qual a próxima grid será iniciada
        for (int i = 0; i < sizeZ; i++, pos.z--) //for para percorrer todo o grid
        {
            pos.x = gridHead.x; //reseta a posição em x, necessário para não fazer uma escada de grids
            for (int j = 0; j < sizeX; j++, pos.x++)
            {
                GameObject currentCell = Instantiate(gridCell, pos, transform.rotation); //instancia a célula de grid
                GridCell cellData = currentCell.GetComponent<GridCell>(); //acessa os componentes da célula
                currentCell.transform.SetParent(grid.transform); //seta o grid como filho do objeto de grid
                currentCell.layer = LayerMask.NameToLayer(myLayer);
                cellData.tilePos = $"{i+1}x{j+1}"; //atribuí na célula a sua posição
                //carregar dados do save na célula
            }
        }
    }

    public void GridToggle(bool toggle) //ativa ou desativa a visibilidade do grid;
    {
        grid.SetActive(toggle);
    }
}
