using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeterHan.PLib.Options;
using Newtonsoft.Json;
using SanchozzONIMods.Lib;

namespace MorePower
{
    [RestartRequired]
    [ConfigFile("config.json", true, true)]
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class MorePowerOptions: BaseOptions<MorePowerOptions>
    {

        [JsonObject(MemberSerialization.OptIn)]
        public sealed class PowerTransformerConfig
        {

            [Option]
            [JsonProperty]
            [Limit(500, 2000)]
            public int PowerTransformerSmallWatt { get; set; } = 1000;

            [Option]
            [JsonProperty]
            [Limit(1000, 8000)]
            public int PowerTransformerWatt { get; set; } = 2000;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public sealed class WireConfig
        {
            [Option]
            [JsonProperty]
            [Limit(500, 2000)]
            public int WireMaxWatt { get; set; } = 1000;

            [Option]
            [JsonProperty]
            [Limit(1000, 8000)]
            public int WireRedefinedMaxWatt { get; set; } = 2000;

            [Option]
            [JsonProperty]
            [Limit(10000, 80000)]
            public int WireHighWattageMaxWatt { get; set; } = 20000;

            [Option]
            [JsonProperty]
            [Limit(25000, 500000)]
            public int WireRedefinedHighWattageMaxWatt { get; set; } = 50000;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public sealed class GeneratorConfig
        {
            [Option]
            [JsonProperty]
            [Limit(200, 1000)]
            public int ManualGeneratorWatt { get; set; } = 400;

            [Option]
            [JsonProperty]
            [Limit(1000, 40000)]
            public int ManualGeneratorCapcityWatt { get; set; } = 10000;

            [Option]
            [JsonProperty]
            [Limit(300, 2000)]
            public int GeneratorWatt { get; set; } = 600;

            [Option]
            [JsonProperty]
            [Limit(1000, 80000)]
            public int GeneratorCapcityWatt { get; set; } = 20000;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public sealed class BatteryConfig
        {
            [Option]
            [JsonProperty]
            [Limit(5000, 40000)]
            public int BatteryCapacity { get; set; } = 10000;

            [Option]
            [JsonProperty]
            [Limit(20000, 100000)]
            public int BatteryMediumCapacity { get; set; } = 40000;

            [Option]
            [JsonProperty]
            [Limit(10000, 100000)]
            public int BatterySmartCapacity { get; set; } = 20000;
        }

        [Option]
        [JsonProperty]
        public PowerTransformerConfig PowerTransformer { get; set; }= new PowerTransformerConfig();

        [Option]
        [JsonProperty]
        public WireConfig Wire { get; set; } = new WireConfig();

        [Option]
        [JsonProperty]
        public GeneratorConfig Generator { get; set; } = new GeneratorConfig();

        [Option]
        [JsonProperty]
        public BatteryConfig Battery { get; set;} = new BatteryConfig();
    }
}
