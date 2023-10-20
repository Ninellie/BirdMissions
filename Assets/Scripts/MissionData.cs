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
    [Space]
    [Header("Mission connections")]
    [SerializeField] private int _id;
    [SerializeField] private int _pairId;
    [SerializeField] private int[] _variantId;
    [SerializeField] private int[] _nextMissionsId;
    [SerializeField] private bool _anyPreviousMissionForUnlock;
    [Space]
    [Header("Hero parameters")]
    [SerializeField] private int _selectedHeroPoints;
    [SerializeField] private int _unlockedHero;
    [SerializeField] private List<HeroPointsData> _heroPoints;
    [Space]
    [Header("Map position")]
    [SerializeField] private Vector2 _mapCoordinates;
    [Space]
    [Header("Description")]
    [SerializeField] private string _title;
    [SerializeField] private string _preMissionText;
    [SerializeField] private string _inMissionText;
    [SerializeField] private string _allyTeamText;
    [SerializeField] private string _enemyTeamText;
    [Space]
    [Header("Current mission status")]
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
    public bool AnyPreviousMissionForUnlock => _anyPreviousMissionForUnlock;
}