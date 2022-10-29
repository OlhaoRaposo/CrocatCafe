using UnityEngine;

public class EditMode : MonoBehaviour
{
    public static GameObject SelectedObject;
    public static bool isEditing = false;

    private void Update()
    {
        RotateInput();
        DeleteInput();
    }

    public void ToggleEdit(bool toggle)
    {
        isEditing = toggle;
    }

    public void RotateInput()
    {
        if(Input.GetMouseButtonDown(1) && isEditing)
        {
            if(SelectedObject != null)
            {
                SelectedObject.GetComponent<DragableObject>().Rotate();
            }
        }
    }

    public void DeleteInput()
    {
        if(Input.GetKeyDown(KeyCode.Backspace) && isEditing)
        {
            if(SelectedObject != null)
            {
                SelectedObject.GetComponent<DragableObject>().Remove();
            }
        }
    }
}
