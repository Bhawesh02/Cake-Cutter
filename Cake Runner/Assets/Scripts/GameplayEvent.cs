using System;

public static class GameplayEvent
{
    public static event Action OnCakeCut;

    public static void SendOnCakeCut()
    {
        OnCakeCut?.Invoke();
    }
    
    public static event Action OnFrostCollision;

    public static void SendOnFrostCollision()
    {
        OnFrostCollision?.Invoke();
    }
    
    public static event Action OnCreamCollision;

    public static void SendOnCreamCollision()
    {
        OnCreamCollision?.Invoke();
    }
}