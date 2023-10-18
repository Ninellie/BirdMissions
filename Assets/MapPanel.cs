using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapPanel : MonoBehaviour
{
    [SerializeField] private UIController _UIController;
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;

    [SerializeField] private GameObject _missionPrefab;
    [SerializeField] private List<Mission> _missions;

    [SerializeField] private Color _lockedColor = Color.gray;
    [SerializeField] private Color _unlockedColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.yellow;
    [SerializeField] private Color _passedColor = Color.green;
    [SerializeField] private float _activeMissionScale = 1.5f;
    [SerializeField] private float _notActiveMissionScale = 0.5f;


    /// <summary>
    /// Выполняется после прохождения миссии
    /// </summary>
    public void UpdateMap()
    {
        UpdateMissionStates();
    }

    public void ConstructMap()
    {
        InstantiateMissions();
        ArrangeMissions();
        SetPreviousMissions();
        SetPairs();
    }

    /// <summary>
    /// Вызывается кликом по открытой миссии
    /// </summary>
    /// <param name="missionId"></param>
    public void SelectMission(int missionId)
    {
        if (_repository.GetActiveMissionData() != null)
        {
            var activeMissionId = _repository.GetActiveMissionData().Id;
            if (missionId == activeMissionId) return;
            UnlockMission(activeMissionId);
        }

        ActivateMission(missionId);
        _UIController.UpdateInfo();
        _UIController.ShowInfoPanel();
    }

    private void ActivateMission(int missionId)
    {
        _repository.SetMissionState(missionId, MissionState.Active);
        foreach (var mission in _missions.Where(mission => mission.Id == missionId))
        {
            UpdateMissionState(mission, MissionState.Active);
        }
    }

    private void UnlockMission(int missionId)
    {
        _repository.SetMissionState(missionId, MissionState.Unlocked);
        foreach (var mission in _missions.Where(mission => mission.Id == missionId))
        {
            UpdateMissionState(mission, MissionState.Unlocked);
        }
    }

    private void UpdateMissionStates()
    {
        foreach (var mission in _missions)
        {
            var state = _repository.GetMissionState(mission.Id);
            UpdateMissionState(mission, state);
        }
    }

    private void UpdateMissionState(Mission mission, MissionState state)
    {
        mission.State = state;
        switch (state)
        {
            case MissionState.Unlocked:
                mission.MissionIcon.color = _unlockedColor;
                mission.transform.localScale = new Vector2(_notActiveMissionScale, _notActiveMissionScale);
                break;
            case MissionState.Locked:
                mission.MissionIcon.color = _lockedColor;
                mission.transform.localScale = new Vector2(_notActiveMissionScale, _notActiveMissionScale);
                break;
            case MissionState.Active:
                mission.MissionIcon.color = _selectedColor;
                mission.transform.localScale = new Vector2(_activeMissionScale, _activeMissionScale);
                break;
            case MissionState.Passed:
                mission.MissionIcon.color = _passedColor;
                mission.transform.localScale = new Vector2(_notActiveMissionScale, _notActiveMissionScale);
                break;
            case MissionState.Blocked:
                mission.gameObject.SetActive(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void InstantiateMissions()
    {
        foreach (var mission in _missions)
        {
            Destroy(mission);
        }
        _missions.Clear();
        var missionIdList = _repository.GetMissionIdList();
        _missions = new List<Mission>(missionIdList.Count);
        foreach (var id in missionIdList)
        {
            var mission = Instantiate(_missionPrefab, gameObject.transform).GetComponent<Mission>();
            mission.SetMapPanel(this);
            mission.Id = id;
            _missions.Add(mission);
        }
    }

    private void ArrangeMissions()
    {
        foreach (var mission in _missions)
        {
            var mapPosition = _repository.GetMapPosition(mission.Id);
            mission.transform.localPosition = mapPosition;
        }
    }

    private void SetPreviousMissions()
    {
        foreach (var mission in _missions)
        {
            var prevMissionsId = _repository.GetPreviousMissionsId(mission.Id);
            var prevMissions = new List<Transform>();
            foreach (var m in _missions)
            {
                prevMissions.AddRange(from prevMissionId in prevMissionsId where m.Id == prevMissionId select m.transform);
            }
            mission.SetPreviousMissions(prevMissions);
        }
    }

    private void SetPairs()
    {
        foreach (var mission in _missions)
        {
            var pairId = _repository.GetPair(mission.Id);

            foreach (var m in _missions.Where(m => m.Id == pairId))
            {
                mission.SetPair(m.transform);
            }
        }
    }
}