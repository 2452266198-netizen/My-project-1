using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject boxPrefab;
    public GameObject goalPrefab;
    public Transform centerPoint;

    private readonly int[,] levelData =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 3, 1 },
        { 1, 0, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 2, 0, 0, 1 },
        { 1, 0, 1, 0, 0, 1, 0, 1 },
        { 1, 0, 2, 0, 0, 0, 3, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        if (wallPrefab == null || boxPrefab == null || goalPrefab == null)
        {
            Debug.LogError("[MapGenerator] Missing wall, box, or goal prefab.");
            return;
        }

        Vector3 startPos = centerPoint != null ? centerPoint.position : transform.position;

        for (int y = 0; y < levelData.GetLength(0); y++)
        {
            for (int x = 0; x < levelData.GetLength(1); x++)
            {
                Vector3 spawnPos = new Vector3(startPos.x + x, startPos.y - y, startPos.z);

                switch (levelData[y, x])
                {
                    case 1:
                        Instantiate(wallPrefab, spawnPos, Quaternion.identity, transform);
                        break;
                    case 2:
                        Instantiate(boxPrefab, spawnPos, Quaternion.identity, transform);
                        break;
                    case 3:
                        Instantiate(goalPrefab, spawnPos, Quaternion.identity, transform);
                        break;
                }
            }
        }
    }
}
