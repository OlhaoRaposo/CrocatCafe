using UnityEngine;

public class EditMode : MonoBehaviour
{
    public static bool isEditing = false;

    public void ToggleEdit(bool toggle)
    {
        isEditing = toggle;
    }
}
