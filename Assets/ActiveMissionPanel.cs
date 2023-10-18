using TMPro;
using UnityEngine;

public class ActiveMissionPanel : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;

    [SerializeField] private TMP_Text _enemyTeamText;
    [SerializeField] private TMP_Text _allyTeamText;
    [SerializeField] private TMP_Text _inMissionText;

    public void UpdateInfo()
    {
        var data = _repository.GetActiveMissionData();
        _inMissionText.text = data.InMissionText;
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