using System;
using System.Collections.Generic;

public class MissionProgress
{
    private uint _passed;
    private uint _opened;
    private uint _blocked;

    public MissionProgress()
    {
        _passed = 0;
        _opened = 0;
        _blocked = 0;
    }

    private MissionProgress(uint passed, uint opened, uint blocked)
    {
        _passed = passed;
        _opened = opened;
        _blocked = blocked;
    }

    public string Serialize()
    {
        return $"{_passed};{_opened};{_blocked}";
    }

    public static MissionProgress Deserialize(string data)
    {
        var s = data.Split(';');
        return new MissionProgress(uint.Parse(s[0]), uint.Parse(s[1]), uint.Parse(s[2]));
    }

    private static void Add(int index, ref uint value)
    {
        if (index is < 0 or > 31)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Недопустимый номер миссии");
        }
        value |= (uint)1 << index;
    }

    private static void Remove(int index, ref uint value)
    {
        if (index is < 0 or > 31)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Недопустимый номер миссии");
        }

        value &= ~((uint)1 << index);
    }

    public void AddPassed(int index)
    {
        Add(index, ref _passed);
        Remove(index, ref _opened);
        Remove(index, ref _blocked);
    }

    public void AddOpened(int index)
    {
        Add(index, ref _opened);
        Remove(index, ref _passed);
        Remove(index, ref _blocked);
    }

    public void AddBlocked(int index)
    {
        Add(index, ref _blocked);
        Remove(index, ref _passed);
        Remove(index, ref _opened);
    }

    private static int[] Get(ref uint value)
    {
        var list = new List<int>(32);

        for (int i = 0; i < 32; i++)
        {
            if ((value & i) > 0)
            {
                list.Add(i);
            }
        }

        return list.ToArray();
    }
    public int[] GetOpened()
    {
        return Get(ref _opened);
    }

    public int[] GetPassed()
    {
        return Get(ref _passed);
    }

    public int[] GetBlocked()
    {
        return Get(ref _blocked);
    }
}