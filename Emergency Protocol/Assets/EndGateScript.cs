using System.Collections;
using UnityEngine;

public class EndGateScript : MonoBehaviour
{
    private IEnumerator winEnd;
    void Awake()
    {
        winEnd = GameObject.Find("GameManager").GetComponent<GameManagerScript>().WinEnd();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            StartCoroutine(winEnd);
        }
    }
}
