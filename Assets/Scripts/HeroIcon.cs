using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _id;
    [SerializeField] private TMP_Text _heroName;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private HeroState _state;
    [SerializeField] private Image _heroPortrait;
    [SerializeField] private Image _heroImage;

    [SerializeField] private HeroPanel _heroPanel;

    public HeroPanel HeroPanel
    {
        get => _heroPanel;
        set => _heroPanel = value;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    public TMP_Text HeroName => _heroName;
    public TMP_Text Points => _points;
    public HeroState State
    {
        get => _state;
        set => _state = value;
    }
    public Image HeroPortrait => _heroPortrait;
    public Image _HeroImage => _heroImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_state != HeroState.Unlocked) return;
        _heroPanel.SelectHero(Id);
    }
}