using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _id;
    [SerializeField] private MissionState _state;
    [SerializeField] private List<Transform> _nextMission;
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
        if (_nextMission == null) return;
        Gizmos.color = Color.green;
        foreach (var previousMission in _nextMission)
        {
            Gizmos.DrawLine(gameObject.transform.position, previousMission.position);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(gameObject.transform.position, _pair.position);
    }

    //public void SetUiController(OldUIController value) => _oldUiController = value;
    public void SetMapPanel(MapPanel value) => _UIController = value;
    //public void SetMissionsManager(MapMissionsManager value) => _missionsManager = value;
    public void SetNextMissions(List<Transform> missions) => _nextMission = missions;
    public void SetPair(Transform pair) => _pair = pair;

    public void Block()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_state != MissionState.Unlocked) return;
        _UIController.SelectMission(_id);
    }
}