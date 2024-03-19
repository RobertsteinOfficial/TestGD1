using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= GameOver;
    }

    private void Start()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
