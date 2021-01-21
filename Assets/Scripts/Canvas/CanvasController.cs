using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private static int Score;
    
    private PlayerController PlayerController;
    public Text scoreText;
    public Text bulletsText;
    public Image playerHealthImage;
    public Text DieText;

    private void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }



    void Update()
    {
        scoreText.text = "Score: " + Score.ToString();
        int PlayerBullets = PlayerController.PlayerBullets;
        bulletsText.text = "Bullets: " + PlayerBullets.ToString();

        if (PlayerController.PlayerHealth <= 0)
        { 
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Die();
        }

        playerHealthImage.fillAmount = (PlayerController.PlayerHealth / PlayerController.MaxPlayerHealth);
    }



    private void Die()
    {
        scoreText.enabled = false;
        bulletsText.enabled = false;
        playerHealthImage.enabled = false;
        DieText.text = "YOU DIE\n" + "SCORE: " + Score.ToString() + "\nPress ENTER to play again";
        DieText.gameObject.SetActive(true);
    }



    public static int Scoring(int value)
    {
        return Score += value;
    }
}
