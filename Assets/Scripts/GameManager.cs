using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public int highscore;

    public Text scoreText;

    public Text highScoreText;

    public GameObject gameOverPanel;

    public static GameManager Instance;

    public AudioClip[] sliceSounds;

    private AudioSource _audioSource;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetHighScore();
        _audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    private void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highscore.ToString();
    }

    public void ContactedBomb()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        PlayBombSound();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void PlayeSliceSound()
    {
        AudioClip sliceSound = sliceSounds[0];
        _audioSource.PlayOneShot (sliceSound);
    }

    public void PlayBombSound()
    {
         AudioClip sliceSound = sliceSounds[1];
        _audioSource.PlayOneShot (sliceSound);
    }
}
