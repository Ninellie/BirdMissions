using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionDataRepository : MonoBehaviour
{
    [SerializeField] private List<MissionData> _missionDataList;
    [SerializeField] private List<HeroData> _heroesDataList;
    private IMissionDataRepository _innerRepository;

    private void Awake()
    {
        _innerRepository = GetComponent<IMissionDataRepository>();
        _heroesDataList = _innerRepository.GetHeroesData();
        _missionDataList = _innerRepository.GetMissionsData();
    }

    public MissionData GetActiveMissionData()
    {
        return _missionDataList.FirstOrDefault(missionData => missionData.State == MissionState.Active);
    }

    public List<MissionData> GetPreviousMissionsData(int missionData)
    {
        return _missionDataList.Where(data => data.NextMissionsId.Any(m => m == missionData)).ToList();
    }

    public MissionData GetMissionData(int missionId)
    {
        return _missionDataList.FirstOrDefault(missionData => missionData.Id == missionId);
    }

    public List<HeroData> GetAllHeroData()
    {
        return _heroesDataList;
    }

    public HeroData GetActiveHeroData()
    {
        return _heroesDataList.FirstOrDefault(heroData => heroData.State == HeroState.Active);
    }

    public HeroData GetHeroData(int heroId)
    {
        return _heroesDataList.FirstOrDefault(heroData => heroData.Id == heroId);
    }

    public void AddHeroPointsToHero(int heroId, int pointsAmount)
    {
        foreach (var heroData in _heroesDataList.Where(heroData => heroData.Id == heroId))
        {
            heroData.Points += pointsAmount;
        }
    }

    public void SetHeroState(int heroId, HeroState heroState)
    {
        foreach (var heroData in _heroesDataList.Where(heroData => heroData.Id == heroId))
        {
            heroData.State = heroState;
        }
    }

    public void LockAllMissions()
    {
        foreach (var missionData in _missionDataList)
        {
            missionData.State = MissionState.Locked;
        }
    }

    public void SetMissionState(int missionId, MissionState missionState)
    {
        foreach (var missionData in _missionDataList.Where(missionData => missionData.Id == missionId))
        {
            missionData.State = missionState;
        }
    }

    public List<int> GetMissionIdList()
    {
        return _missionDataList.Select(missionData => missionData.Id).Distinct().ToList();
    }

    public Vector2 GetMapPosition(int missionId)
    {
        return _missionDataList.Where(missionData => missionData.Id == missionId).Select(mission => mission.MapCoordinates).FirstOrDefault();
    }

    public int GetPair(int missionId)
    {
        return (_missionDataList.Where(missionData => missionData.Id == missionId).Select(missionData => missionData.PairId)).FirstOrDefault();
    }

    public MissionState GetMissionState(int missionId)
    {
        foreach (var missionData in _missionDataList.Where(missionData => missionData.Id == missionId))
        {
            return missionData.State;
        }
        return MissionState.Locked;
    }
}