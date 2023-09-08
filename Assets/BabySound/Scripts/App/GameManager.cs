using System;
using SingleApp;

public class GameManager : PersistentSingleton<GameManager>
{
    public static Action<int> OnChangeCoin;
    public static Action<int> OnChangeDiamond;
    public static Action<bool> OnPlayMusic;
    public static Action<int> OnChooseSong;
    public static Action<float> SetTimeStop;

    private void Start()
    {
    }
}