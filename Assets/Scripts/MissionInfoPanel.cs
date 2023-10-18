using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoPanel : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;

    [SerializeField] private TMP_Text _missionTitleText;
    [SerializeField] private TMP_Text _preMissionText;
    [SerializeField] private Button _startButton;
    [SerializeField] private RectTransform _rectTransform;

    [SerializeField] private float _openingDuration = 0.5f;
    [SerializeField] private Ease _openingEase = Ease.OutCirc;

    [SerializeField] private float _closingDuration = 0.5f;
    [SerializeField] private Ease _closingEase = Ease.OutCirc;

    public void UpdateInfo()
    {
        var data = _repository.GetActiveMissionData();
        _missionTitleText.text = data.Title;
        _preMissionText.text = data.PreMissionText;
    }

    public void Open()
    {
        _rectTransform.DOAnchorPosX(_rectTransform.rect.width, _openingDuration).SetEase(_openingEase).OnComplete(()=> _startButton.interactable = true);
    }

    public void Close()
    {
        _startButton.interactable = false;
        _rectTransform.DOAnchorPosX(0, _closingDuration).SetEase(_closingEase);
    }
}