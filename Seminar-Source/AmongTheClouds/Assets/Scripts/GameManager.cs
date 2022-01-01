using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject infoButton;
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner1;
    public GameObject enemySpawner2;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;
    public GameObject exitButton;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

 
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                GameOverGO.SetActive(false);

                GameTitleGO.SetActive(true);

                playButton.SetActive(true);
                infoButton.SetActive(true);
                exitButton.SetActive(true);
              
                break;

            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0; //resetiranje vrij.

                //sakrij dugme play i info tijekom same igre
                playButton.SetActive(false);
                infoButton.SetActive(false);
                exitButton.SetActive(false);
                GameTitleGO.SetActive(false);

                playerShip.GetComponent<PlayerControl>().Init();

                enemySpawner1.GetComponent<Enemy1Spawner>().ScheduleEnemySpawner();
                enemySpawner2.GetComponent<Enemy2Spawner>().ScheduleEnemySpawner();

                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();


                break;

            case GameManagerState.GameOver:

                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                enemySpawner1.GetComponent<Enemy1Spawner>().UnscheduleEnemySpawner();
                enemySpawner2.GetComponent<Enemy2Spawner>().UnscheduleEnemySpawner();

                GameOverGO.SetActive(true);

                Invoke("ChangeToOpeningState", 6f);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //pritisak gumba play
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
