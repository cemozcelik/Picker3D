using DG.Tweening;
using Signals;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI> ();
    [Space]
    [SerializeField] private List<Image> stageImages = new List<Image>();

    #endregion

    #endregion

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetNewLevelValue += OnSetNewLevelValue;
        UISignals.Instance.onUpdateStageColor += OnSetStageColor;
    }

    private void UnSubscribeEvents()
    {
        UISignals.Instance.onSetNewLevelValue -= OnSetNewLevelValue;
        UISignals.Instance.onUpdateStageColor -= OnSetStageColor;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void OnSetNewLevelValue(int levelValue)
    {
        if(levelValue <= 0) levelValue = 1;
        levelTexts[0].text = levelValue.ToString();
        int value = ++levelValue;
        levelTexts[1].text = value.ToString();
    }

    [Button("OnSetStageColor")]
    private void OnSetStageColor(int value)
    {
        stageImages[value].DOColor(Color.red, .35f).SetEase(Ease.Linear);
    }
}
