using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Optional win panel")]
    public GameObject winPanel;

    [Header("Optional next scene")]
    public string nextSceneName;

    private bool hasWon;

    private void OnEnable()
    {
        GameEvents.OnResetCommand += ReloadCurrentLevel;
        GameEvents.OnMoveFinished += CheckWinCondition;
        GameEvents.OnBoxGoalChanged += OnBoxGoalChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnResetCommand -= ReloadCurrentLevel;
        GameEvents.OnMoveFinished -= CheckWinCondition;
        GameEvents.OnBoxGoalChanged -= OnBoxGoalChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentLevel();
        }
    }

    private void OnBoxGoalChanged(bool isAtGoal)
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (hasWon)
        {
            return;
        }

        BoxLogic[] allBoxes = FindObjectsByType<BoxLogic>(FindObjectsSortMode.None);
        if (allBoxes.Length == 0)
        {
            return;
        }

        foreach (BoxLogic box in allBoxes)
        {
            if (!box.isAtGoal)
            {
                return;
            }
        }

        hasWon = true;
        Debug.Log("[GameManager] All boxes reached goals.");
        GameEvents.TriggerAllBoxesInPlace();
        ShowWinScreen();
    }

    private void ShowWinScreen()
    {
        if (winPanel == null)
        {
            return;
        }

        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClick_NextOrRestart()
    {
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        ReloadCurrentLevel();
    }

    private void ReloadCurrentLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
