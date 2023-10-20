using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroPanel : MonoBehaviour
{
    [SerializeField] private MissionDataRepository _repository;

    [SerializeField] private List<HeroIcon> _heroIcons;
    [SerializeField] private GameObject _heroIconPrefab;
    
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

    public void ConstructHeroes()
    {
        foreach (var heroIcon in _heroIcons)
        {
            Destroy(heroIcon);
        }

        _heroIcons.Clear();

        var data = _repository.GetAllHeroData();

        _heroIcons = new List<HeroIcon>();

        foreach (var heroData in data)
        {
            var heroIcon = Instantiate(_heroIconPrefab, gameObject.transform).GetComponent<HeroIcon>();

            heroIcon.Id = heroData.Id;
            heroIcon.HeroName.text = heroData.HeroName;
            heroIcon.Points.text = heroData.Points.ToString();
            heroIcon.State = heroData.State;
            heroIcon.HeroPortrait.sprite = heroData.Portrait;
            heroIcon.HeroPanel = this;
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
        var heroData = _repository.GetHeroData(heroIcon.Id);
        heroIcon.Points.text = heroData.Points.ToString();
        heroIcon.State = heroData.State;
        SetHeroState(heroIcon, heroData.State);
    }

    private void SetHeroState(HeroIcon heroIcon, HeroState state)
    {
        heroIcon.State = state;

        switch (state)
        {
            case HeroState.Active:
                heroIcon._HeroImage.color = _selectedColor;
                heroIcon.HeroPortrait.color = Color.white;
                break;
            case HeroState.Unlocked:
                heroIcon._HeroImage.color = _unlockedColor;
                heroIcon.HeroPortrait.color = Color.white;
                break;
            case HeroState.Locked:
                heroIcon._HeroImage.color = _lockedColor;
                heroIcon.HeroPortrait.color = _lockedColor;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        
    }
}