using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroPanel : MonoBehaviour
{
    [SerializeField] private ScriptableObjectMissionDataRepository _repository;

    [SerializeField] private List<HeroIcon> _heroIcons;
    [SerializeField] private GameObject _heroIconPrefab;
    [SerializeField] private int _initialActiveHeroId = 1;
    [SerializeField] private Color _lockedColor = Color.gray;
    [SerializeField] private Color _unlockedColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.yellow;

    public void SelectHero(int heroId)
    {
        var activeHeroId = _repository.GetActiveHeroData().Id;
        if (heroId == activeHeroId) return;
        _repository.SetHeroState(activeHeroId, HeroState.Unlocked);
        _repository.SetHeroState(heroId, HeroState.Active);
        UpdateHeroIcons();
    }

    private void Start()
    {
        _repository.SetHeroState(_initialActiveHeroId, HeroState.Active);
        ConstructHeroes();
    }

    private void ConstructHeroes()
    {
        foreach (var heroIcon in _heroIcons)
        {
            Destroy(heroIcon);
        }

        _heroIcons.Clear();

        var data = _repository.GetHeroData();

        _heroIcons = new List<HeroIcon>();

        foreach (var heroData in data)
        {
            var heroIcon = Instantiate(_heroIconPrefab, gameObject.transform).GetComponent<HeroIcon>();

            heroIcon._id = heroData.Id;
            heroIcon._heroName.text = heroData.HeroName;
            heroIcon._points.text = heroData.Points.ToString();
            heroIcon._state = heroData.State;
            heroIcon._heroPanel = this;
            SetHeroState(heroIcon, heroData.State);
            _heroIcons.Add(heroIcon);
        }
    }

    public void UpdateHeroIcons()
    {
        foreach (var heroIcon in _heroIcons)
        {
            UpdateHeroInfo(heroIcon);
        }
    }

    private void UpdateHeroInfo(HeroIcon heroIcon)
    {
        var heroData = _repository.GetHero(heroIcon._id);
        heroIcon._points.text = heroData.Points.ToString();
        heroIcon._state = heroData.State;
        SetHeroState(heroIcon, heroData.State);
    }

    private void SetHeroState(HeroIcon heroIcon, HeroState state)
    {
        heroIcon._state = state;

        switch (state)
        {
            case HeroState.Active:
                heroIcon._heroIcon.color = _selectedColor;
                break;
            case HeroState.Unlocked:
                heroIcon._heroIcon.color = _unlockedColor;
                break;
            case HeroState.Locked:
                heroIcon._heroIcon.color = _lockedColor;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        
    }
}