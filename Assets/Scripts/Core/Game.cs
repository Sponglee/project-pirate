using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public static class Priority
{
    public const int Gameplay = 0;
    public const int Menu = 1;
}

public class Game : AntAbstractBootstrapper
{
    #region AntAbstractBootstrapper Implementation

    public Transform UIRoot;
    public StateMachine StateMachine;
    public CameraManager CameraManager;
    public GameManager GameManager;
    public PlayerController PlayerController;

    public override void Configure(IInjectContainer aContainer)
    {
        aContainer.RegisterSingleton<Game>(this);
        aContainer.RegisterSingleton<StateMachine>(StateMachine);
        aContainer.RegisterSingleton<CameraManager>(CameraManager);
        aContainer.RegisterSingleton<GameManager>(GameManager);
        // .. конфигурация DI Container.
    }

    #endregion

    #region Unity Calls

    private void Start()
    {
        InitializeSystems();
        // Добавляем все сущности в игровой движок.
        AntEngine.AddEntitiesFromHierarchy("Level");

        StateMachine.Initialize();


    }

    private void Update()
    {
        AntEngine.Execute();
    }

    private void FixedUpdate()
    {
        AntEngine.ExecuteFixed();
    }

    private void LateUpdate()
    {
        AntEngine.ExecuteLate();
    }

    #endregion

    #region Private Methods

    private void InitializeSystems()
    {
        AntEngine.Add<Gameplay>(Priority.Gameplay);
        AntEngine.Add<Menu>(Priority.Menu);

        // .. инициализация других систем
    }



    #endregion
}