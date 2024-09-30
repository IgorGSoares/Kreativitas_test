using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject panelBottomMenu;
    [SerializeField] GameObject panelPrepareGame;
    [SerializeField] GameObject panelGame;
    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelWinGame;


    public void StartMatch()
    {
        panelPrepareGame.SetActive(false);
        panelBottomMenu.SetActive(false);

        panelGame.SetActive(true);
    }

    public void Pause()
    {
        panelPause.SetActive(true);
        panelGame.SetActive(false);
    }

    public void Resume()
    {
        panelPause.SetActive(false);
        panelGame.SetActive(true);
    }

    public void GameOver()
    {
        panelGame.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public void WinGame()
    {
        panelGame.SetActive(false);
        panelWinGame.SetActive(true);
    }
}
