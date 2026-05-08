using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    Debug.Log($"Hit: {other.gameObject.name} | Tag: {other.tag} | Layer: {LayerMask.LayerToName(other.gameObject.layer)}");

    if (other.CompareTag("Obstacle") &&
        other.gameObject.layer != LayerMask.NameToLayer("Walkable"))
    {
        GameManager.Instance.TriggerGameOver();
    }
}
}