using TMPro;
using UnityEngine;

public class ActiveMissionPanel : MonoBehaviour
{
    [SerializeField] private MissionDataRepository _repository;

    [SerializeField] private TMP_Text _enemyTeamText;
    [SerializeField] private TMP_Text _allyTeamText;
    [SerializeField] private TMP_Text _inMissionText;

    public void UpdateInfo()
    {
        var data = _repository.GetActiveMissionData();
        _inMissionText.text = data.InMissionText;
        _allyTeamText.text = $"Союзники \r\n \r\n {data.AllyTeamText}";
        _enemyTeamText.text = $"Противники \r\n \r\n {data.EnemyTeamText}";
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}