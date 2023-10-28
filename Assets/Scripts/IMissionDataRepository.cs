using System.Collections.Generic;

public interface IMissionDataRepository
{
    List<MissionData> GetMissionsData();
    List<HeroData> GetHeroesData();
}