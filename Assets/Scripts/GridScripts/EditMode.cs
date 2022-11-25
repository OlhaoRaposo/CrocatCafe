using UnityEngine;

public class EditMode : MonoBehaviour
{
    public static GameObject selectedObject;
    public static bool isEditing = false;

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
        if(Input.GetMouseButtonDown(1) && isEditing)
        {
            if(selectedObject != null)
            {
                selectedObject.GetComponent<DragableObject>().Rotate();
            }
        }
    }

    public void DeleteInput()
    {
        if(Input.GetKeyDown(KeyCode.Backspace) && isEditing)
        {
            if(selectedObject != null)
            {
                selectedObject.GetComponent<DragableObject>().Remove();
            }
        }
    }

    private void RemoveUnusedObjects()
    {
        if(isEditing == false)
        {
            GameObject[] unusedObjects = GameObject.FindGameObjectsWithTag("Furniture");

            foreach (GameObject unusedObject in unusedObjects)
            {
                if (unusedObject.GetComponent<DragableObject>() != null)
                {
                    if(unusedObject.GetComponent<DragableObject>().currentCell == null)
                    {
                        selectedObject = unusedObject;
                        selectedObject.GetComponent<DragableObject>().Remove();
                    }
                }
            }
        }
    }
}
