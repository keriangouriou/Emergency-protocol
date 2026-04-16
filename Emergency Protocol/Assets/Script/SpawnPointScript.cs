using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;
    private Collider invisWall;
    private void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        invisWall = GetComponentInChildren<GetCollider>().GetColliderInvisWall();
        invisWall.enabled = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            gameManagerScript.characterSpawnPosition = transform.position;
            invisWall.enabled = true;
        }
    }
}
