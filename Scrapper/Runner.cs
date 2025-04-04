namespace Scrapper;

public class Runner
{
    private readonly IFrontOfficerovider _frontOfficerovider;
    private readonly IScheduleProvider _scheduleProvider;

    public Runner(IFrontOfficerovider frontOfficerovider, IScheduleProvider scheduleProvider)
    {
        _frontOfficerovider = frontOfficerovider;
        _scheduleProvider = scheduleProvider;
    }
    public async Task Run()
    {
       var apiData = await _frontOfficerovider.GetApiData();
       var allSchedules = await _scheduleProvider.GetSchedule(apiData);

       var biharYogaEvents =
           allSchedules.schedule.SelectMany(s => 
               s.scheduleEvents.Where(e => 
                   e.qualifiedName.StartsWith("BIHAR YOGA")));
    }
}