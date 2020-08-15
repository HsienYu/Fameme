using System;
using UnityEngine;
using Random = System.Random;

public enum PillType
{
    Red = 0,
    White = 1,
    Yellow = 2,
    Pink = 3
}

public class PillScore
{
    public int Red { get; set; }
    public int White { get; set; }
    public int Yellow { get; set; }
    public int Pink { get; set; }

    public void Reset()
    {
        Red = 0;
        White = 0;
        Yellow = 0;
        Pink = 0;
    }
}

public class GameManager
{
    private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());
    public static GameManager Instance => lazy.Value;

    public const int MaxQuestion = 8;

    private Random _seed = new Random();

    public PillScore Pills { get; set; } = new PillScore();
    public int CurrentStep { get; private set; } = 0;

    public int CurrentStepPercent => Convert.ToInt32(Math.Floor(CurrentStep / MaxQuestion * 100f));

    private GameManager()
    {
        //Debug.Log("GameManager");
    }

    public void EatPill()
    {
        SelectPill();
        CurrentStep++;
    }

    private void SelectPill()
    {
        var v = _seed.Next(4);
        switch ((PillType)v)
        {

            case PillType.White:
                Pills.White++;
                break;
            case PillType.Yellow:
                Pills.Yellow++;
                break;
            case PillType.Pink:
                Pills.Pink++;
                break;
            case PillType.Red:
            default:
                Pills.Red++;
                break;
        }
    }

    public int GetPillScore(PillType pt)
    {
        switch (pt)
        {
            case PillType.Red:
                return Convert.ToInt32(Math.Floor((decimal)(this.Pills.Red / MaxQuestion)));
            case PillType.White:
                return Convert.ToInt32(Math.Floor((decimal)(this.Pills.White / MaxQuestion)));
            case PillType.Yellow:
                return Convert.ToInt32(Math.Floor((decimal)(this.Pills.Yellow / MaxQuestion)));
            case PillType.Pink:
                return Convert.ToInt32(Math.Floor((decimal)(this.Pills.Pink / MaxQuestion)));
            default: return 0;
        }
    }

    public void Reset()
    {
        CurrentStep = 0;
        Pills.Reset();
    }

    public void DumpInfo()
    {
        Debug.LogFormat("Step:{0}, Red:{1}, White:{2}, Yellow:{3}, Pink:{4}",
            CurrentStep,
            Pills.Red, Pills.White, Pills.Yellow, Pills.Pink);
    }
}
