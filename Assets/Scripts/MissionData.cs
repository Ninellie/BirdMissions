using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroPointsData
{
    public int heroId;
    public int pointsAmount;
}

[CreateAssetMenu(fileName = "MissionData", menuName = "Game/Mission")]
public class MissionData : ScriptableObject
{
    [SerializeField] private int _missionId;
    [SerializeField] private int _id;
    [SerializeField] private int _pairId;
    [SerializeField] private int[] _variantId;
    [SerializeField] private int[] _nextMissionsId;
    [SerializeField] private string _title;
    [SerializeField] private Vector2 _mapCoordinates;
    [SerializeField] private string _preMissionText;
    [SerializeField] private string _inMissionText;
    [SerializeField] private string _allyTeamText;
    [SerializeField] private string _enemyTeamText;
    [SerializeField] private int _unlockedHero;
    [SerializeField] private int _selectedHeroPoints;
    [SerializeField] private List<HeroPointsData> _heroPoints;
    [SerializeField] private MissionState _missionState;

    public int Id => _id;
    public int PairId => _pairId;
    public int[] NextMissionsId => _nextMissionsId;
    public int[] VariantId => _variantId;
    public string Title => _title;
    public Vector2 MapCoordinates => _mapCoordinates;
    public string PreMissionText => _preMissionText;
    public string InMissionText => _inMissionText;
    public int UnlockedHero => _unlockedHero;
    public List<HeroPointsData> HeroPoints => _heroPoints;
    public int SelectedHeroPoints => _selectedHeroPoints;
    public MissionState State
    {
        get => _missionState;
        set => _missionState = value;
    }

    public string AllyTeamText => _allyTeamText;

    public string EnemyTeamText => _enemyTeamText;
}