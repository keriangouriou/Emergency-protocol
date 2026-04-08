using UnityEngine;

public class ScreenCenterMovement : MonoBehaviour
{
    public float screenSpeed = 10f;
    private Vector3 screenMove;

    void Start()
    {
        screenMove = new Vector3(0,0,screenSpeed);   
    }
    void Update()
    {
        transform.position += screenMove * Time.deltaTime;
    }
}
