using System.Linq;
using UnityEngine;

public class GameSessionController : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;
    [SerializeField] private UIController _UIController;
    [SerializeField] private int _initialUnlockedMissionId;

    private void Start()
    {
        InitGameSession();
    }

    public void InitGameSession()
    {
        _repository.LockAllMissions();
        _repository.SetMissionState(_initialUnlockedMissionId, MissionState.Unlocked);
        _UIController.Init();
        _UIController.UpdateMap();
        _UIController.UpdateHeroes();
    }

    public void PassSelectedMission()
    {
        var data = _repository.GetActiveMissionData();
        // Начислить очки героям
        AddHeroPoints(data);
        // Обновить состояния миссий
        MakeMissionChanges(data);

        _UIController.UpdateHeroes();
        _UIController.UpdateMap();
    }

    private void MakeMissionChanges(MissionData activeMissionData)
    {
        foreach (var variantId in activeMissionData.VariantId)
        {
            _repository.SetMissionState(variantId, MissionState.Blocked);
        }

        // Получаем Id следующих миссий
        var nextMissionsId = _repository.GetNextMissionId(activeMissionData.Id);
        foreach (var id in nextMissionsId)
        {
            // Получаем данные следующей миссии после активной
            var d = _repository.GetMissionData(id);
            
            // Проверяем, достаточно ли любой предыдущей миссии чтобы анлокнуть эту миссю
            //if (d.AnyPreviousMissionForUnlock)
            //{
                // Если да, то просто анлокаем её
                _repository.SetMissionState(id, MissionState.Unlocked);
            //} // Если нет надо проверить, пройдены ли остальные предыдущие миссии этой миссии (d)
            //else
            //{
            //    // Если хотя бы одна миссия до не пройдена, то возвращаемся.
            //    var allPreviousMissionsPassed = d.PreviousMissionsId.All(previousMissionsId => _repository.GetMissionState(previousMissionsId) == MissionState.Passed);
            //    if (!allPreviousMissionsPassed) continue;
            //    _repository.SetMissionState(id, MissionState.Unlocked);
            //}
        }

        _repository.SetMissionState(activeMissionData.Id, MissionState.Passed);

        if (activeMissionData.PairId != activeMissionData.Id)
        {
            _repository.SetMissionState(activeMissionData.PairId, MissionState.Locked);
        }
    }

    private void AddHeroPoints(MissionData activeMissionData)
    {
        // Добивать очки герою который проходил миссию
        var selectedHeroPoints = activeMissionData.SelectedHeroPoints;
        var activeHeroId = _repository.GetActiveHeroData().Id;
        _repository.AddHeroPointsToHero(activeHeroId, selectedHeroPoints);
        foreach (var heroPointsData in activeMissionData.HeroPoints)
        {
            _repository.AddHeroPointsToHero(heroPointsData.heroId, heroPointsData.pointsAmount);
        }
    }
}