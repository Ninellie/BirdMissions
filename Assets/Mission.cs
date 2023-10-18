using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _id;
    [SerializeField] private MissionState _state;
    [SerializeField] private List<Transform> _previousMissions;
    [SerializeField] private Transform _pair;
    [SerializeField] private MapPanel _UIController;
    [SerializeField] private Image _missionIcon;

    public Image MissionIcon => _missionIcon;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public MissionState State
    {
        set => _state = value;
    }

    private void OnDrawGizmos()
    {
        if (_previousMissions == null) return;
        Gizmos.color = Color.green;
        foreach (var previousMission in _previousMissions)
        {
            Gizmos.DrawLine(gameObject.transform.position, previousMission.position);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(gameObject.transform.position, _pair.position);
    }

    //public void SetUiController(OldUIController value) => _oldUiController = value;
    public void SetMapPanel(MapPanel value) => _UIController = value;
    //public void SetMissionsManager(MapMissionsManager value) => _missionsManager = value;
    public void SetPreviousMissions(List<Transform> missions) => _previousMissions = missions;
    public void SetPair(Transform pair) => _pair = pair;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_state != MissionState.Unlocked) return;
        


        _UIController.SelectMission(_id);

        //_oldUiController.SelectMission(_id);
        //_oldUiController.UpdateInfo();
        //_oldUiController.PullOutPreMissionPanel();
        //_oldUiController.PullOutHeroPanel();

        // _UIController.ShowInfo
    }
}