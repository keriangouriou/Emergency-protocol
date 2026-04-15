using UnityEngine;

public class DisableInvisibleWall : MonoBehaviour
{
    private Collider invisWall;
    private void Awake()
    {
        invisWall = GetComponentInChildren<GetCollider>().GetColliderInvisWall();
        invisWall.enabled = false;
    }
    public void DisableWall()
    {
        invisWall.enabled = false;
    }
}
