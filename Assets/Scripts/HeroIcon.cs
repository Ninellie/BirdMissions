using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroIcon : MonoBehaviour, IPointerClickHandler
{
    public int _id;
    public TMP_Text _heroName;
    public TMP_Text _points;
    public HeroState _state;
    public Image _heroIcon;
    
    public HeroPanel _heroPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_state != HeroState.Unlocked) return;
        _heroPanel.SelectHero(_id);
    }
}