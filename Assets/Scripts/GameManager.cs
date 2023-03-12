using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anthill.Core;
using Anthill.Inject;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [Inject] public Game Game { get; set; }

    #region Events
    public class GameFinishedEvent : UnityEvent<bool> { };
    public static GameFinishedEvent OnGameFinished = new GameFinishedEvent();
    public class MenuOpenEvent : UnityEvent<bool> { };
    public static MenuOpenEvent OnMenuOpen = new MenuOpenEvent();

    #endregion

    #region private

    #endregion

    #region public

    #endregion

    #region properties

    #endregion

    #region UnityCalls

    public async void SlowTime(float targetScale, float targetDuration)
    {
        Time.timeScale = targetScale;
        await Task.Delay(Mathf.RoundToInt(targetDuration) * 1000);
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        AntInject.Inject<GameManager>(this);
    }

    private void Start()
    {
        AntEngine.Get<Menu>().Get<LobbyController>().Show();
    }

    #endregion


    public void StartGame()
    {
        AntEngine.Get<Menu>().Get<LobbyController>().Hide();
        AntEngine.Get<Menu>().Get<HealthBarController>().Show();
        Game.StateMachine.ChangeState(StateEnum.PlayState);
    }

    public void LevelComplete()
    {

    }

    public void GameOver()
    {

    }


    #region Private Methods

    #endregion
}
