using UnityEngine;
using UnityEngine.UI;

public class CameraSettings : MonoBehaviour
{
    [SerializeField]private Slider movement, spin, zoom;
    [SerializeField]private GodCamera camera;
    private void Start()
    {
        movement.value = PlayerPrefs.GetFloat("movementCamera", movement.value);
        spin.value = PlayerPrefs.GetFloat("spinCamera", spin.value);
        zoom.value = PlayerPrefs.GetFloat("zoomCamera", zoom.value);

        // camera.speed = movement.value;
        // camera.rotation = spin.value;
        // camera.zoomStrength = zoom.value;
    }

    // Update is called once per frame
    public void MovementCameraChange()
    {
        camera.speed = movement.value;
        PlayerPrefs.SetFloat("movementCamera", movement.value);
    }

    public void SpinCameraChange()
    {
        camera.rotation = spin.value;
        PlayerPrefs.SetFloat("spinCamera", spin.value);
    }

    public void ZoomCameraChange()
    {
        camera.zoomStrength = zoom.value;
        PlayerPrefs.SetFloat("spinCamera", spin.value);
    }
}
