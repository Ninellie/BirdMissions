using UnityEngine;

public enum HeroState
{
    Active,
    Unlocked,
    Locked,
}

[CreateAssetMenu(fileName = "HeroData", menuName = "Game/Hero")]
public class HeroData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _heroName;
    [SerializeField] private int _points;
    [SerializeField] private HeroState _state;
    //[SerializeField] private Texture2D _portrait;

    public int Id => _id;
    public string HeroName => _heroName;
    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public HeroState State
    {
        get => _state;
        set => _state = value;
    }
}