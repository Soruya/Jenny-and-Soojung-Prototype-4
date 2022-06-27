using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource playerHit;
    public AudioSource playerLose;
    public AudioSource enemyHit;
    public AudioSource winCheer;
    public AudioSource winPop;

    public void playPlayerHit()
    {
        playerHit.Play();
    }
    public void playPlayerLose()
    {
        playerLose.Play();
    }
    public void playEnemyHit()
    {
        enemyHit.Play();
    }
    public void playWinCheer()
    {
        winCheer.Play();
    }
    public void playWinPop()
    {
        winPop.Play();
    }

}
