using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    [Tooltip("Whether this box is currently on a goal tile.")]
    public bool isAtGoal = false;

    [Tooltip("Optional effect spawned when the box reaches a goal.")]
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Goal"))
        {
            return;
        }

        isAtGoal = true;
        Debug.Log($"[BoxLogic] {name} reached a goal.");

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        GameEvents.TriggerBoxGoalChanged(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Goal"))
        {
            return;
        }

        isAtGoal = false;
        Debug.Log($"[BoxLogic] {name} left a goal.");
        GameEvents.TriggerBoxGoalChanged(false);
    }
}
