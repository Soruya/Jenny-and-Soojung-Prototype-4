using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerScript playerScript;
    public GameObject winText;
    public GameObject confetti;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        confetti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.win)
        {
            confetti.SetActive(true);
            winText.SetActive(true);
        }
        Restart();
        Quit();
    }

    void Restart()
    {
        // Win Condition and then Restart
        if (playerScript.win && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerScript.win = false;
        }
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
