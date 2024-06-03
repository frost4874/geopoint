using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Text ScoreText;
    private int scoreVal = 0;
    [SerializeField] private AudioSource collect;
    [SerializeField] private AudioSource level2;
    [SerializeField] private AudioSource end;

    void Update()
    {
        // Your update logic here if needed
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish1"))
        {
            SceneManager.LoadScene("Level2");
            level2.Play();
        }
        if (other.gameObject.CompareTag("Finish2"))
        {
            SceneManager.LoadScene("Level3");
            level2.Play(); // Using level3 correctly
        }
        if (other.gameObject.CompareTag("Finish3"))
        {
            SceneManager.LoadScene("WinEndScene");
            end.Play();
        }
        if (other.gameObject.CompareTag("Collectible"))
        {
            UpdateScore();
            collect.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Reload the current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void UpdateScore()
    {
        // Parse the score text into an integer
        if (int.TryParse(ScoreText.text, out scoreVal))
        {
            // Update the score value
            scoreVal += 1;

            // Update the score text with the new value
            ScoreText.text = scoreVal.ToString();
        }
        else
        {
            // Parsing failed, show a warning
            Debug.LogWarning("Failed to parse score text into an integer.");
        }
    }
}
