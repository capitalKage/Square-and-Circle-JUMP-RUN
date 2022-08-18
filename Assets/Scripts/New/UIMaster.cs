using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMaster : MonoBehaviour
{
    PlayerCollision playerCollision;
    public TMP_Text gameOverText;
    public TMP_Text victoryText;

    // Start is called before the first frame update
    void Start()
    {
        playerCollision = FindObjectOfType<PlayerCollision>();
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCollision.gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
        }
        if(playerCollision.victory == true)
        {
            victoryText.gameObject.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
