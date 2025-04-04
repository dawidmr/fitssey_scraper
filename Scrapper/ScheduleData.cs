namespace Scrapper;

public class ScheduleData
{
    public Schedule[] schedule { get; set; }
    public object[] filters { get; set; }
}

public class Schedule
{
    public string date { get; set; }
    public ScheduleEvents[] scheduleEvents { get; set; }
}

public class ScheduleEvents
{
    public string referenceId { get; set; }
    public int totalCapacity { get; set; }
    public int onlineCapacity { get; set; }
    public int waitingListCapacity { get; set; }
    public object nonVaccinatedCapacity { get; set; }
    public string color { get; set; }
    public object liveStreamUrl { get; set; }
    public object liveStreamPassword { get; set; }
    public object liveStreamPasswordRevealed { get; set; }
    public object privateNotes { get; set; }
    public bool isFree { get; set; }
    public bool isLiveStream { get; set; }
    public bool isCancelled { get; set; }
    public bool isHidden { get; set; }
    public bool isBookableOnline { get; set; }
    public string startsAt { get; set; }
    public string endsAt { get; set; }
    public Member member { get; set; }
    public Room room { get; set; }
    public ScheduleMeta scheduleMeta { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public bool hasStarted { get; set; }
    public bool hasEnded { get; set; }
    public bool isInProgress { get; set; }
    public int remainCapacity { get; set; }
    public int remainOnlineCapacity { get; set; }
    public int remainFrontOfficeCapacity { get; set; }
    public int remainWaitingListCapacity { get; set; }
    public int remainCapacityForMale { get; set; }
    public int remainCapacityForFemale { get; set; }
    public int bookedSpots { get; set; }
    public object bookedSpotsForMale { get; set; }
    public object bookedSpotsForFemale { get; set; }
    public int bookedWaitingListSpots { get; set; }
    public int bookedOnlineSpots { get; set; }
    public object maleCapacity { get; set; }
    public object femaleCapacity { get; set; }
    public int day { get; set; }
    public bool isLiveStreamBroadcasting { get; set; }
    public bool isLiveStreamPasswordProtected { get; set; }
    public object clientVisit { get; set; }
    public bool isAvailableForBookingAhead { get; set; }
    public bool isAvailableBeforeStartTime { get; set; }
    public string qualifiedName { get; set; }
    public string serviceType { get; set; }
    public Members[] members { get; set; }
}

public class Member
{
    public string nickname { get; set; }
    public string publicBiography { get; set; }
    public User user { get; set; }
    public object picture { get; set; }
    public string qualifiedName { get; set; }
}

public class User
{
    public string fullName { get; set; }
    public string guid { get; set; }
}

public class Room
{
    public string name { get; set; }
    public bool isDefault { get; set; }
    public Location location { get; set; }
    public string qualifiedName { get; set; }
    public bool hasSmartLock { get; set; }
    public string guid { get; set; }
}

public class Location
{
    public string name { get; set; }
    public object directions { get; set; }
    public object picture { get; set; }
    public Address address { get; set; }
    public Phone phone { get; set; }
    public bool enableMap { get; set; }
    public string guid { get; set; }
}

public class Address
{
    public string street { get; set; }
    public string postalCode { get; set; }
    public object state { get; set; }
    public string city { get; set; }
    public object countryCode { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public bool hasFullAddress { get; set; }
    public string fullAddress { get; set; }
}

public class Phone
{
    public object mobilePhone { get; set; }
    public object homePhone { get; set; }
    public string workPhone { get; set; }
    public bool isMobilePhoneVerified { get; set; }
    public bool hasPrimaryPhone { get; set; }
    public string primaryPhone { get; set; }
}

public class ScheduleMeta
{
    public int bookingBehavior { get; set; }
    public bool isBookableOnline { get; set; }
    public ClassService classService { get; set; }
    public string guid { get; set; }
}

public class ClassService
{
    public string name { get; set; }
    public string description { get; set; }
    public object picture { get; set; }
    public ExperienceLevel experienceLevel { get; set; }
    public string excerpt { get; set; }
    public string serviceType { get; set; }
    public string guid { get; set; }
}

public class ExperienceLevel
{
    public Name name { get; set; }
    public int numericLevel { get; set; }
    public string guid { get; set; }
}

public class Name
{
    public En_EN en_EN { get; set; }
    public Pl_PL pl_PL { get; set; }
}

public class En_EN
{
    public string value { get; set; }
}

public class Pl_PL
{
    public string value { get; set; }
}

public class Members
{
    public string nickname { get; set; }
    public string publicBiography { get; set; }
    public User1 user { get; set; }
    public object picture { get; set; }
    public string qualifiedName { get; set; }
}

public class User1
{
    public string fullName { get; set; }
    public string guid { get; set; }
}

