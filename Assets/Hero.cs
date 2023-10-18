using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private MapMissionsManager _missionManager;
    [SerializeField] private Button _startButton;
    [SerializeField] private Selectable _selectable;
    [SerializeField] private int _id;

    //public void SetInfo(HeroData data)
    //{

    //    _id = data.Id;
    //    _nameText.text = data.HeroName;
    //    _pointsText.text = data.Points.ToString();

    //    //_selectable.interactable = !data.Locked;
    //}

    //public void Lock()
    //{
    //    _selectable.interactable = false;
    //}

    //public void Unlock()
    //{
    //    _selectable.interactable = true;
    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    _missionManager.SelectHero(_id);
    //    _startButton.interactable = true;
    //}
}