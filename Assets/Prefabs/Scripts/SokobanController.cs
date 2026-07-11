using System.Collections;
using UnityEngine;

public class SokobanController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 1f;
    public float moveDuration = 0.15f;
    public LayerMask obstacleLayer;

    private bool isMoving;

    private void OnEnable()
    {
        GameEvents.OnMoveCommand += TryMove;
    }

    private void OnDisable()
    {
        GameEvents.OnMoveCommand -= TryMove;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            TryMove(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            TryMove(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            TryMove(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            TryMove(Vector3.right);
        }
    }

    public void TryMove(Vector3 direction)
    {
        if (isMoving)
        {
            return;
        }

        direction = NormalizeGridDirection(direction);
        if (direction == Vector3.zero)
        {
            return;
        }

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, moveDistance, obstacleLayer))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return;
            }

            if (hit.collider.CompareTag("Box"))
            {
                Transform box = hit.collider.transform;
                if (Physics.Raycast(box.position, direction, moveDistance, obstacleLayer))
                {
                    return;
                }

                StartCoroutine(SmoothMove(box, direction));
            }
        }

        StartCoroutine(SmoothMove(transform, direction));
    }

    private static Vector3 NormalizeGridDirection(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0f ? Vector3.right : Vector3.left;
        }

        if (Mathf.Abs(direction.y) > 0f)
        {
            return direction.y > 0f ? Vector3.up : Vector3.down;
        }

        return Vector3.zero;
    }

    private IEnumerator SmoothMove(Transform target, Vector3 direction)
    {
        isMoving = true;
        Vector3 startPos = target.position;
        Vector3 endPos = startPos + direction * moveDistance;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            target.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.position = endPos;
        isMoving = false;

        if (target == transform)
        {
            GameEvents.TriggerMoveFinished();
        }
    }
}
