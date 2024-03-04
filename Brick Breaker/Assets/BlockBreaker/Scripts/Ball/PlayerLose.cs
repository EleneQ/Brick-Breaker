using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LoseCollider"))
        {
            StartCoroutine(LevelManager.instance.ReplayLevel());
        }     
    }
}
