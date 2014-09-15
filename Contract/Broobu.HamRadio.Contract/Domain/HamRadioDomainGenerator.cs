using System;

namespace Broobu.HamRadio.Contract.Domain
{
    public class HamRadioDomainGenerator
    {
        public static LogbookItem[] GetTestObjects()
        {
            return new[]
            {
                new LogbookItem
                {
                    Id = "LogbookItem1",
                    MyCallId = "ON8RL",
                    MyCallModifier = "/P",
                    WorkedStationId = "ON3NL",
                    Band = "2M",
                    Modulation = "FM",
                    Started = DateTime.Now.ToUniversalTime(),
                    ExtraInfo = "Dit is wat extra info",
                    RxReport = "48"
                },
                new LogbookItem
                {
                    Id = "LogbookItem2",
                    MyCallId = "ON8RL",
                    MyCallModifier = "/P",
                    WorkedStationId = "ON4NL",
                    Band = "40M",
                    Modulation = "SSB",
                    Started = DateTime.Now.ToUniversalTime(),
                    ExtraInfo = "Laat ons hierover wat meer vertellen",
                    TxReport = "59"
                },
                new LogbookItem
                {
                    Id = "LogbookItem3",
                    MyCallId = "ON4NL",
                    MyCallModifier = "/P",
                    WorkedStationId = "ON3NL",
                    Band = "2M",
                    Modulation = "FM",
                    Started = DateTime.Now.ToUniversalTime()
                },
                new LogbookItem
                {
                    Id = "LogbookItem4",
                    MyCallId = "ON8RL",
                    MyCallModifier = "/P",
                    WorkedStationId = "PA4CL",
                    Band = "2M",
                    Modulation = "FM",
                    Started = DateTime.Now.ToUniversalTime()
                }
            };
        }
    }
}