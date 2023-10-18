using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptableObjectMissionDataRepository : MonoBehaviour
{
    [SerializeField] private List<MissionData> _missionDataList;
    [SerializeField] private List<HeroData> _heroesDataList;

    private void Awake()
    {

    }

    public HeroData GetActiveHeroData()
    {
        return _heroesDataList.FirstOrDefault(heroData => heroData.State == HeroState.Active);
    }

    public MissionData GetActiveMissionData()
    {
        return _missionDataList.FirstOrDefault(missionData => missionData.State == MissionState.Active);
    }

    public MissionData GetMissionData(int missionId)
    {
        return _missionDataList.FirstOrDefault(missionData => missionData.Id == missionId);
    }

    public void AddHeroPointsToAllHeroes(int pointsAmount)
    {
        foreach (var heroData in _heroesDataList)
        {
            heroData.Points += pointsAmount;
        }
    }

    public void AddHeroPointsToHero(int heroId, int pointsAmount)
    {
        foreach (var heroData in _heroesDataList.Where(heroData => heroData.Id == heroId))
        {
            heroData.Points += pointsAmount;
        }
    }

    public List<int> GetNextMissionId(int missionId)
    {
        return (from missionData in _missionDataList where missionData.PreviousMissionsId.Any(prevId => prevId == missionId) select missionData.Id).ToList();
    }

    public HeroData GetHero(int heroId)
    {
        return _heroesDataList.FirstOrDefault(heroData => heroData.Id == heroId);
    }

    public List<HeroData> GetHeroData()
    {
        return _heroesDataList;
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

    public string GetMissionTitle(int missionId)
    {
        foreach (var missionData in _missionDataList.Where(missionData => missionData.Id == missionId))
        {
            return missionData.Title;
        }

        return "";
    }

    public string GetPreMissionText(int missionId)
    {
        foreach (var missionData in _missionDataList.Where(missionData => missionData.Id == missionId))
        {
            return missionData.PreMissionText;
        }

        return "";
    }

    public string GetInMissionText(int missionId)
    {
        return _missionDataList.Where(missionData => missionData.Id == missionId).Select(mission => mission.InMissionText).FirstOrDefault();
    }

    public int[] GetPreviousMissionsId(int missionId)
    {
        return _missionDataList.Where(missionData => missionData.Id == missionId).Select(missionData => missionData.PreviousMissionsId).FirstOrDefault();
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
        foreach (var missionData in _missionDataList)
        {
            if (missionData.Id == missionId)
            {
                var i = missionData.PairId;
                return i;
            }
        }

        return 0;
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