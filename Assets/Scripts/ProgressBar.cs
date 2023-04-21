using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    [SerializeField] private float loadTime;

    void Start()
    {
        StartLoading(10);
    }

    public void FixedUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    public void StartLoading(float loadTime)
    {
        this.loadTime = loadTime;
        InvokeRepeating("UpdateProgress", 0, 1);
    }

    private void UpdateProgress()
    {
        if (progressBar.value < 1.0f)
        {
            progressBar.value += 1 / loadTime / 2;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
