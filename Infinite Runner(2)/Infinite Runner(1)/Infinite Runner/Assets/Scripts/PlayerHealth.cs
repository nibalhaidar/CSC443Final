using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // your death logic here (reload scene, show game over UI, etc.)
    }
}