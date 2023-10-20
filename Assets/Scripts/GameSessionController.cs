using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class GameSessionController : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;
    [SerializeField] private UIController _UIController;
    [SerializeField] private int _initialUnlockedMissionId;
    [SerializeField] private int _initialActiveHeroId = 1;

    private void Start()
    {
        SetDataToDefault();
        InitGameSession();
    }

    public void PassSelectedMission()
    {
        var data = _repository.GetActiveMissionData();
        // Начислить очки героям
        AddHeroPoints(data);
        // Разблокировать героя
        UnlockHero(data);
        // Блокируем пары
        LockPairs(data);
        // Обновить состояния миссий
        TryUnlockNextMissions(data);
        _repository.SetMissionState(data.Id, MissionState.Passed);
        // Обновить карту и панель героев
        _UIController.UpdateHeroes();
        _UIController.UpdateMap();
    }

    private void InitGameSession()
    {
        _UIController.Init();
        _UIController.UpdateMap();
        _UIController.UpdateHeroes();
    }

    private void SetDataToDefault()
    {
        SetMissionDataToDefault();
        SetHeroesToDefault();
    }

    private void SetMissionDataToDefault()
    {
        _repository.LockAllMissions();
        _repository.SetMissionState(_initialUnlockedMissionId, MissionState.Unlocked);
    }

    private void SetHeroesToDefault()
    {
        var heroDataList = _repository.GetAllHeroData();
        LockAllHeroes(heroDataList);
        _repository.SetHeroState(_initialActiveHeroId, HeroState.Active);
        AnnulHeroPoints(heroDataList);
    }

    private void LockAllHeroes(List<HeroData> heroDataList)
    {
        foreach (var heroData in heroDataList)
        {
            _repository.SetHeroState(heroData.Id, HeroState.Locked);
        }
    }

    private void AnnulHeroPoints(List<HeroData> heroDataList)
    {
        foreach (var heroData in heroDataList)
        {
            _repository.AddHeroPointsToHero(heroData.Id, heroData.Points * -1);
        }
    }

    private void UnlockHero(MissionData data)
    {
        if (data.UnlockedHero == 0) return;
        if (_repository.GetHeroData(data.UnlockedHero).State != HeroState.Locked) return;
        _repository.SetHeroState(data.UnlockedHero, HeroState.Unlocked);
    }

    private void TryUnlockNextMissions(MissionData activeMissionData)
    {
        foreach (var nextMissionId in activeMissionData.NextMissionsId)
        {
            var nextMissionData = _repository.GetMissionData(nextMissionId);
            if (nextMissionData.State != MissionState.Locked) continue;
            if (nextMissionData.AnyPreviousMissionForUnlock)
            {
                UnlockMission(nextMissionData);
            }
            else
            {
                //var prevMissions = _repository.GetPreviousMissionsData(nextMissionId);
                // Если хотя бы одна из предыдущих миссии следующей миссии не пройдена, ничего не делаем
                //var unlock = prevMissions.Where(prevMission => prevMission.Id != activeMissionData.Id).All(prevMission => prevMission.State == MissionState.Passed);
                var unlock = GetIsMissionAbleToUnlocking(nextMissionData, activeMissionData);
                if (!unlock) continue;
                _repository.SetMissionState(nextMissionData.Id, MissionState.Unlocked);
                BlockVariants(nextMissionData);
            }
        }
    }

    private void BlockVariants(MissionData missionData)
    {
        foreach (var variantId in missionData.VariantId)
        {
            _repository.SetMissionState(variantId, MissionState.Blocked);
        }
    }

    private bool GetIsMissionAbleToUnlocking(MissionData missionData, MissionData activeMissionData)
    {
        var prevMissions = _repository.GetPreviousMissionsData(missionData.Id);
        var unlock = prevMissions.Where(prevMission => prevMission.Id != activeMissionData.Id)
            .All(prevMission => prevMission.State == MissionState.Passed);
        return unlock;
    }

    private void UnlockMission(MissionData missionData)
    {
        _repository.SetMissionState(missionData.Id, MissionState.Unlocked);
        BlockVariants(missionData);
    }

    private void LockPairs(MissionData activeMissionData)
    {
        if (activeMissionData.PairId == activeMissionData.Id) return;
        _repository.SetMissionState(activeMissionData.PairId, MissionState.Locked);
    }

    private void AddHeroPoints(MissionData activeMissionData)
    {
        var selectedHeroPoints = activeMissionData.SelectedHeroPoints;
        var activeHeroId = _repository.GetActiveHeroData().Id;
        _repository.AddHeroPointsToHero(activeHeroId, selectedHeroPoints);

        foreach (var heroPointsData in activeMissionData.HeroPoints)
        {
            AddPointsToNonActiveHero(heroPointsData.heroId, heroPointsData.pointsAmount);
        }
    }

    private void AddPointsToNonActiveHero(int heroId, int pointsAmount)
    {
        if (pointsAmount < 0)
        {
            _repository.AddHeroPointsToHero(heroId, pointsAmount);
            return;
        }

        if (_repository.GetHeroData(heroId).State == HeroState.Unlocked)
        {
            _repository.AddHeroPointsToHero(heroId, pointsAmount);
        }
    }
}