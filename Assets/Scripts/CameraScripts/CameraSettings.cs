using UnityEngine;
using UnityEngine.UI;

public class CameraSettings : MonoBehaviour
{
    [SerializeField]private Slider movement, spin, zoom;
    [SerializeField]private GodCamera myCamera;
    private void Start()
    {
        movement.value = PlayerPrefs.GetFloat("movementCamera", movement.value);
        spin.value = PlayerPrefs.GetFloat("spinCamera", spin.value);
        zoom.value = PlayerPrefs.GetFloat("zoomCamera", zoom.value);

        myCamera.speed = movement.value;
        myCamera.rotation = spin.value;
        myCamera.zoomStrength = zoom.value;
    }

    // Update is called once per frame
    public void MovementCameraChange()
    {
        myCamera.speed = movement.value;
        PlayerPrefs.SetFloat("movementCamera", movement.value);
    }

    public void SpinCameraChange()
    {
        myCamera.rotation = spin.value;
        PlayerPrefs.SetFloat("spinCamera", spin.value);
    }

    public void ZoomCameraChange()
    {
        myCamera.zoomStrength = zoom.value;
        PlayerPrefs.SetFloat("spinCamera", spin.value);
    }
}
