using UnityEngine;

public class EditMode : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject[] gridList;
    public bool isEditing = false;

    public static EditMode instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        RotateInput();
        DeleteInput();
    }

    public void ToggleEdit(bool toggle)
    {
        isEditing = toggle;
        RemoveUnusedObjects();
    }

    public void RotateInput()
    {
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z)) && isEditing)
        {
            if (selectedObject != null)
            {
                selectedObject.GetComponent<DragableObject>().Rotate();
            }
        }
    }

    public void DeleteInput()
    {
        if ((Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.X)) && isEditing)
        {
            if (selectedObject != null)
            {
                selectedObject.GetComponent<DragableObject>().Remove();
            }
        }
    }

    public void UpdateLayers()
    {
        for (int i = 0; i < gridList.Length; i++)
        {
            if (selectedObject.layer != gridList[i].layer)
            {
                gridList[i].SetActive(false);
            }
            else
            {
                GodCamera.instance.SetDestinyPos(gridList[i]);
            }
        }
    }

    private void RemoveUnusedObjects()
    {
        if (isEditing == false)
        {
            GameObject[] unusedObjects = GameObject.FindGameObjectsWithTag("Furniture");

            foreach (GameObject unusedObject in unusedObjects)
            {
                if (unusedObject.GetComponent<DragableObject>() != null)
                {
                    if (unusedObject.GetComponent<DragableObject>().currentCell == null)
                    {
                        selectedObject = unusedObject;
                        selectedObject.GetComponent<DragableObject>().Remove();
                    }
                }
            }

            GameObject[] unusedShowcases = GameObject.FindGameObjectsWithTag("ShowCase");

            foreach (GameObject unusedShowcase in unusedShowcases)
            {
                if (unusedShowcase.GetComponent<DragableObject>() != null)
                {
                    if (unusedShowcase.GetComponent<DragableObject>().currentCell == null)
                    {
                        selectedObject = unusedShowcase;
                        selectedObject.GetComponent<DragableObject>().Remove();
                    }
                }
            }
        }
    }
}
