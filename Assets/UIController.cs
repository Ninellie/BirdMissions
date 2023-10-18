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
    }

    public void UpdateMap()
    { 
        _mapPanel.UpdateMap();
    }

    public void UpdateHeroes()
    {
        _heroPanel.UpdateHeroIcons();
    }

    public void UpdateInfo()
    {
        _missionInfoPanel.UpdateInfo();
        _activeMissionPanel.UpdateInfo();
    }

    public void ShowInfoPanel()
    {
        _missionInfoPanel.Open();
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