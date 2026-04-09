using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;
    private void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            gameManagerScript.Lose();
        }
    }
}
