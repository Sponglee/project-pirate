using Anthill.Core;

public class Gameplay : AntScenario
{
    public Gameplay() : base("Gameplay")
    {
        // ...
    }

    public override void AddedToEngine()
    {
        base.AddedToEngine();
        Add<HealthSystem>();
        Add<AIInputSystem>();
        Add<KeyboardInputSystem>();
        Add<CharacterMovementSystem>();

        // .. добавляйте здесь любые системы в рамках геймплея
    }

    public override void RemovedFromEngine()
    {
        Remove<HealthSystem>();
        Remove<AIInputSystem>();
        Remove<KeyboardInputSystem>();
        Remove<CharacterMovementSystem>();
        base.RemovedFromEngine();
    }
}