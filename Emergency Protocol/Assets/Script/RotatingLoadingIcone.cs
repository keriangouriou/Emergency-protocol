using UnityEngine;

public class RotatingLoadingIcone : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 rotationSpeed = new Vector3(0,0,-30);
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.Rotate(rotationSpeed*Time.deltaTime);
    }
}
