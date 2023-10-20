using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectMissionDataRepository : MonoBehaviour, IMissionDataRepository
{
    [SerializeField] private List<MissionData> _missionDataList;
    [SerializeField] private List<HeroData> _heroesDataList;
    public List<MissionData> GetMissionsData()
    {
        return _missionDataList;
    }

    public List<HeroData> GetHeroesData()
    {
        return _heroesDataList;
    }
}