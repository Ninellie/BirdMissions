using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MapMissionsManager : MonoBehaviour
{
    [SerializeField] private OldUIController _oldUiController;
    [SerializeField] private int _initialUnlockedMissionId;
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;
    [SerializeField] private GameObject _missionPrefab;
    [SerializeField] private List<Mission> _missions;
    [SerializeField] private List<Hero> _heroIcons;

    [SerializeField] private Color _lockedColor = Color.gray;
    [SerializeField] private Color _unlockedColor = Color.white;
    [SerializeField] private Color _passedColor = Color.yellow;

    [SerializeField] private int _selectedHeroId;

    //private void Start()
    //{
    //    Init();
    //}

    //public void SelectHero(int heroId)
    //{
    //    _selectedHeroId = heroId;
    //}

    //public void PassMission(int missionId)
    //{
    //    // Разлокируем следующие миссии
    //    var nextMissionsId = _repository.GetNextMissionId(missionId);
    //    foreach (var id in nextMissionsId)
    //    {
    //        // Проверить, любая ли из миссий нужна

    //        // Если да, то анлочим её
    //        _repository.SetMissionState(id, MissionState.Unlocked);

    //        // Если нет, то проверяем, пройдены ли остальные её миссии

    //        // Если пройдены, то анлочим её
    //    }

    //    // Делаем эту миссию пройденной
    //    _repository.SetMissionState(missionId, MissionState.Passed);

    //    // Локаем её пары
    //    var pairId = _repository.GetPair(missionId);

    //    if (pairId != missionId)
    //    {
    //        _repository.SetMissionState(pairId, MissionState.Locked);
    //    }

    //    // Добавляем очки героев

    //    // Добавляем героев, которые разблокировались

    //    // Обновляем героев

    //    // Обновляем очки героев

    //    // Обновляем мапус
    //    UpdateMissionStages();
    //}

    //[ContextMenu("Init")]
    //private void Init()
    //{
    //    _repository.LockAllMissions();
    //    _repository.SetMissionState(_initialUnlockedMissionId, MissionState.Unlocked);
    //    InstantiateMissions();
    //    ArrangeMissions();
    //    SetPreviousMissions();
    //    SetPairs();
    //    UpdateMissionStages();
    //}

    //private void UpdateMissionStages()
    //{
    //    foreach (var mission in _missions)
    //    {
    //        var state = _repository.GetMissionState(mission.Id);
    //        mission.State = state;
    //        switch (state)
    //        {
    //            case MissionState.Unlocked:
    //                mission.MissionIcon.color = _unlockedColor;
    //                break;
    //            case MissionState.Locked:
    //                mission.MissionIcon.color = _lockedColor;
    //                break;
    //            case MissionState.Active:
    //                break;
    //            case MissionState.Passed:
    //                mission.MissionIcon.color = _passedColor;
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }
    //    }
    //}

    //private void ArrangeMissions()
    //{
    //    foreach (var mission in _missions)
    //    {
    //        var mapPosition = _repository.GetMapPosition(mission.Id);
    //        mission.transform.localPosition = mapPosition;
    //    }
    //}

    //private void InstantiateMissions()
    //{
    //    foreach (var mission in _missions)
    //    {
    //        Destroy(mission);
    //    }
    //    _missions.Clear();
    //    var missionIdList = _repository.GetMissionIdList();
    //    _missions = new List<Mission>(missionIdList.Count);
    //    foreach (var id in missionIdList)
    //    {
    //        var mission = Instantiate(_missionPrefab, gameObject.transform).GetComponent<Mission>();
    //        //mission.SetMapPanel(_oldUiController);
    //        mission.Id = id;
    //        _missions.Add(mission);
    //    }
    //    _oldUiController.SetMissions(_missions);
    //}

    //private void SetPreviousMissions()
    //{
    //    foreach (var mission in _missions)
    //    {
    //        // Получаем для этой миссии id предыдущих миссий
    //        var prevMissionsId = _repository.GetPreviousMissionsId(mission.Id);

    //        // Создаём список миссий (из того же листа по которому итерируемся)
    //        var prevMissions = new List<Transform>();

    //        // Заполняем этот список
    //        foreach (var m in _missions)
    //        {
    //            prevMissions.AddRange(from prevMissionId in prevMissionsId where m.Id == prevMissionId select m.transform);
    //        }

    //        mission.SetPreviousMissions(prevMissions);
    //    }
    //}

    //private void SetPairs()
    //{
    //    foreach (var mission in _missions)
    //    {
    //        // Получаем для этой миссии id предыдущих миссий
    //        var pairId = _repository.GetPair(mission.Id);

    //        foreach (var m in _missions.Where(m => m.Id == pairId))
    //        {
    //            mission.SetPair(m.transform);
    //        }
    //    }
    //}

    //public void LookAtCurrentMission()
    //{
    //    // Центрировать карту на текущей миссии
    //}

    //public void LookAtMapCenter()
    //{
    //    // Центрировать карту на центре карты
    //}
}