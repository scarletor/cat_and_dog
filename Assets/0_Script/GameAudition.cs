using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Sirenix.OdinInspector;
using System;
public class GameAudition : MonoBehaviour
{
    public static GameAudition ins;
    private void Awake()
    {
        ins = this;
    }


    [SerializeField]
    public SkeletonAnimation anim;
    public SkeletonGraphic animUI;
    public AnimationState animState;
    public int i;


    private void Start()
    {
        gameState = GameStateEnum.Ready;
        StartNewRound();
    }
    public enum CatStateEnum
    {
        none,
        Idle,
        Left,
        Right,
        Up,
        Down
    };

    //Define Enum

    //This is what you need to show in the inspector.
    public CatStateEnum catState;


    [Button]
    public void SetCatState(CatStateEnum state)
    {
        switch (state)
        {
            case CatStateEnum.none:
                break;
            case CatStateEnum.Idle:
                animUI.AnimationState.SetAnimation(0, "Idle", false).MixDuration = 0;

                break;
            case CatStateEnum.Left:
                animUI.AnimationState.SetAnimation(0, "Dance_L", false).MixDuration = 0;

                break;
            case CatStateEnum.Right:
                animUI.AnimationState.SetAnimation(0, "Dance_R", false).MixDuration = 0;


                break;
            case CatStateEnum.Up:
                animUI.AnimationState.SetAnimation(0, "Dance_U", false).MixDuration = 0;


                break;
            case CatStateEnum.Down:
                animUI.AnimationState.SetAnimation(0, "Dance_D", false).MixDuration = 0;

                break;
        }
        catState = state;
    }






    public ScoreUI scoreDog, scoreCat, round;
    public ProgressBar progressBar;
    public TargetInputList targetInputList;
    public InputButton inputButton;

    [Button]
    public void StartNewRound()
    {
        gameState = GameStateEnum.Play;
        progressBar.MoveIndicator();
        targetInputList.CreateNewList(numberArrowToInput);
        inputButton.EnableButton();
        currentIndexInput = 0;
        rightCount = 0;
    }




    public int currentIndexInput, numberArrowToInput, rightCount;
    public void OnClickButtonDownFunc()
    {
        if (currentIndexInput == numberArrowToInput) return;
        if (targetInputList.targetArrowList[currentIndexInput] == InputButtonEnum.Down)
        {
            targetInputList.SetSymbolGreen(currentIndexInput);
            rightCount++;
        }
        else
        {
            targetInputList.SetSymbolRed(currentIndexInput);
        }
        currentIndexInput++;
    }

    public void OnClickButtonUpFunc()
    {
        if (currentIndexInput == numberArrowToInput) return;
        if (targetInputList.targetArrowList[currentIndexInput] == InputButtonEnum.Up)
        {
            targetInputList.SetSymbolGreen(currentIndexInput);
            rightCount++;
        }
        else
        {
            targetInputList.SetSymbolRed(currentIndexInput);
        }
        currentIndexInput++;
    }

    public void OnClickButtonRightFunc()
    {
        if (currentIndexInput == numberArrowToInput) return;
        if (targetInputList.targetArrowList[currentIndexInput] == InputButtonEnum.Right)
        {
            targetInputList.SetSymbolGreen(currentIndexInput);
            rightCount++;
        }
        else
        {
            targetInputList.SetSymbolRed(currentIndexInput);
        }
        currentIndexInput++;
    }

    public void OnClickButtonLeftFunc()
    {
        if (currentIndexInput == numberArrowToInput) return;
        if (targetInputList.targetArrowList[currentIndexInput] == InputButtonEnum.Left)
        {
            targetInputList.SetSymbolGreen(currentIndexInput);
            rightCount++;
        }
        else
        {
            targetInputList.SetSymbolRed(currentIndexInput);
        }
        currentIndexInput++;
    }


    [SerializeField]
    GameStateEnum _gameState;
    public GameStateEnum gameState
    {
        get { return _gameState; }
        set
        {






            _gameState = value;
            switch (value)
            {
                case GameStateEnum.none:
                    break;
                case GameStateEnum.Ready:
                    break;
                case GameStateEnum.Play:
                    break;
                case GameStateEnum.RunAnim:
                    break;
                case GameStateEnum.Rest:
                    Utils.ins.DelayCall(1, () =>
                    {
                        var track = animUI.AnimationState.SetAnimation(0, "Idle", false);
                        track.MixDuration = 0f;
                        StartNewRound();
                    });
                    break;
                case GameStateEnum.Win:
                    break;
                case GameStateEnum.Lose:
                    break;
            }


        }
    }

    public void OnFinishMove()
    {
        gameState = GameStateEnum.RunAnim;
        if (rightCount == numberArrowToInput)
        {
            Debug.LogError("ALL RIGHT");
            animLoopCount = 0;
            PlayAnimLoop();

        }
        else
        {
            Debug.LogError("FAIL MOVE");
            StartNewRound();
        }
    }


    int animLoopCount;
    public void PlayAnimLoop()
    {
        Debug.LogError("PLAY ANIM");
        var track = animUI.AnimationState.SetAnimation(0, GetAnimString(), false);
        track.MixDuration = 0;
        track.Complete += (b) =>
        {
            if (animLoopCount == numberArrowToInput)
            {
                gameState = GameStateEnum.Rest;
                return;
            }
            Debug.LogError(animLoopCount);
            targetInputList.SetSymbolGreenEff(animLoopCount);
            PlayAnimLoop();
            animLoopCount++;
        };

    }


    public string GetAnimString()
    {
        if (targetInputList.targetArrowList[animLoopCount] == InputButtonEnum.Left) return "Dance_L";
        if (targetInputList.targetArrowList[animLoopCount] == InputButtonEnum.Right) return "Dance_R";
        if (targetInputList.targetArrowList[animLoopCount] == InputButtonEnum.Up) return "Dance_U";
        if (targetInputList.targetArrowList[animLoopCount] == InputButtonEnum.Down) return "Dance_D";

        Debug.LogError("BUG");
        return "";
    }
}

public enum GameStateEnum
{
    none,
    Ready,
    Play,
    RunAnim,
    Rest,
    Win,
    Lose
}