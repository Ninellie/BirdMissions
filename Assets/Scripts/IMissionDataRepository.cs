using System.Collections.Generic;

public interface IMissionDataRepository
{
    List<MissionData> GetMissionsData();
    MissionData GetMissionDataById(int id);
}