using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerScript playerScript;
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
        }
        Restart();
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
}
