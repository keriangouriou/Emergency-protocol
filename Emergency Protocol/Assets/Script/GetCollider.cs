using UnityEngine;

public class GetCollider : MonoBehaviour
{
    public Collider GetColliderInvisWall()
    {
        return GetComponent<Collider>();
    }
}
