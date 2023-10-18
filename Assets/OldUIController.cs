using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class OldUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _selectedMissionTitle;
    [SerializeField] private TMP_Text _selectedPreMissionText;
    [SerializeField] private TMP_Text _selectedInMissionText;
    [SerializeField] private RectTransform _preMissionPanel;

    [SerializeField] private RectTransform _heroesPanel;

    [SerializeField] private ScriptableObjectMissionDataRepository _repository;
    [SerializeField] private MapMissionsManager _missionManager;

    [SerializeField] private int _selectedMissionId;
    [SerializeField] private List<Mission> _missions;

    [SerializeField] private Hero _selectedHero;
    [SerializeField] private List<Hero> _heroes;


    //public void PassSelectedMission()
    //{
    //    _missionManager.PassMission(_selectedMissionId);
    //}

    //public void SelectHero(Hero hero)
    //{
    //    _selectedHero = hero;
    //}


    //public void SetMissions(List<Mission> missions)
    //{
    //    _missions = missions;
    //}

    //public void HideMissionPanel()
    //{
    //    _preMissionPanel.DOAnchorPosX(0, 1).SetEase(Ease.InCirc);
    //    _heroesPanel.DOAnchorPosY(0, 1).SetEase(Ease.InCirc);
    //    DeselectMission();
    //}

    //public void SelectMission(int missionId)
    //{
    //    if (_selectedMissionId == missionId) return;
    //    DeselectMission();
    //    _selectedMissionId = missionId;

    //    foreach (var mission in _missions.Where(mission => mission.Id == missionId))
    //    {
    //        mission.transform.localScale *= 2;
    //    }
    //}

    //private void DeselectMission()
    //{
    //    foreach (var mission in _missions.Where(mission => mission.Id == _selectedMissionId))
    //    {
    //        mission.transform.localScale /= 2;
    //    }

    //    _selectedMissionId = 0;
    //}

    //public void UpdateInfo()
    //{
    //    _selectedMissionTitle.text = _repository.GetMissionTitle(_selectedMissionId);
    //    _selectedPreMissionText.text = _repository.GetPreMissionText(_selectedMissionId);
    //    //
    //}

    //public void PullOutPreMissionPanel()
    //{
    //    var rectWidth = _preMissionPanel.rect.width;
    //    _preMissionPanel.DOAnchorPosX(rectWidth, 1).SetEase(Ease.OutCirc);
    //}

    //public void PullOutHeroPanel()
    //{
    //    var rectWidth = _heroesPanel.rect.height;
    //    _heroesPanel.DOAnchorPosY(rectWidth, 1).SetEase(Ease.InCirc);
    //}
}