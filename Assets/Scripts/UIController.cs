using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;
    [SerializeField] private GameSessionController _gameSessionController;

    [SerializeField] private MapPanel _mapPanel;
    [SerializeField] private HeroPanel _heroPanel;
    [SerializeField] private MissionInfoPanel _missionInfoPanel;
    [SerializeField] private ActiveMissionPanel _activeMissionPanel;

    public void Init()
    {
        _mapPanel.ConstructMap();
        _heroPanel.ConstructHeroes();
    }

    public void UpdateMap() => _mapPanel.UpdateMap();

    public void UpdateHeroes() => _heroPanel.UpdateHeroIcons();

    public void OpenInfoPanel() => _missionInfoPanel.Open();

    public void UpdateInfo()
    {
        _missionInfoPanel.UpdateInfo();
        _activeMissionPanel.UpdateInfo();
    }

    /// <summary>
    /// Вызывается по кнопке в MissionInfo панели
    /// </summary>
    public void StartSelectedMission()
    {
        _missionInfoPanel.Close();
        _activeMissionPanel.Open();
    }

    /// <summary>
    /// Вызывается по кнопке в ActiveMission панели
    /// </summary>
    public void PassSelectedMission()
    {
        _gameSessionController.PassSelectedMission();
        _activeMissionPanel.Close();
    }
}