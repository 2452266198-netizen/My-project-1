using UnityEngine;

public class SerialManager : MonoBehaviour
{
    [Header("Serial input is temporarily disabled")]
    public string portName = "COM3";
    public int baudRate = 9600;

    private void Start()
    {
        Debug.Log("[SerialManager] Serial input disabled. Use keyboard controls for now.");
    }

    public void ParseCommand(string command)
    {
        string cmd = command.Trim().ToUpperInvariant();

        switch (cmd)
        {
            case "UP":
            case "U":
            case "W":
                GameEvents.TriggerMove(Vector3.up);
                break;
            case "DOWN":
            case "D":
            case "S":
                GameEvents.TriggerMove(Vector3.down);
                break;
            case "LEFT":
            case "L":
            case "A":
                GameEvents.TriggerMove(Vector3.left);
                break;
            case "RIGHT":
                GameEvents.TriggerMove(Vector3.right);
                break;
            case "RESET":
            case "R":
                GameEvents.TriggerReset();
                break;
            default:
                Debug.LogWarning($"[SerialManager] Unknown command: {cmd}");
                break;
        }
    }
}
