using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Variables
    [Header("Displays")]
    [SerializeField] TMP_Text _scoreText;

    //Timer Variables
    [SerializeField] float timeRemaining = 60f; // 60 seconds
    [SerializeField] float delayBeforeReload = 5f;
    [SerializeField] TMP_Text timerText;            // Reference to UI Text component
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerRunning();
    }

    public void AdjustScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    #region Game States
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    #endregion



    #region Timer
    void TimerRunning()
    {
        if (timeRemaining > 0)
        {
            // Reduce time remaining
            timeRemaining -= Time.deltaTime;

            // Display remaining time (rounded to integer)
            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            // If time runs out, ensure it displays as 0
            timerText.text = "0";
            // Optionally: do something when timer reaches zero
            TimerFinished();
        }
    }

    void TimerFinished()
    {
        StartCoroutine(ReloadSceneAfterDelay());
    }

    private IEnumerator ReloadSceneAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayBeforeReload);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

}
