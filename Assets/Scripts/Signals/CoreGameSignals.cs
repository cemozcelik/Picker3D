using Enums;
using UnityEngine;
using UnityEngine.Events;
using Extensions;

public class CoreGameSignals : MonoSingleton<CoreGameSignals>
{
    public UnityAction<GameStates> onChangeGameState = delegate { };
    public UnityAction<int> onLevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction onLevelSuccessful = delegate { };
    public UnityAction onLevelFailed = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
    public UnityAction onPlay = delegate { };
    public UnityAction onReset = delegate { };

    public UnityAction onStageAreaSuccessful = delegate { };
    public UnityAction onStageAreaEntered = delegate { };
}