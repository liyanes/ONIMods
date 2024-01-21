using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using PeterHan.PLib.Core;
using PeterHan.PLib.Database;
using PeterHan.PLib.Options;
using PeterHan.PLib.PatchManager;
using SanchozzONIMods.Lib;
using UnityEngine;
using static SanchozzONIMods.Lib.Utils;

namespace MorePower
{

    public class MorePowerPatch: KMod.UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary(true);
            BaseOptions<MorePowerOptions>.Reload();
            base.OnLoad(harmony);

            new PLocalization().Register();

            if (!File.Exists(Path.Combine(modInfo.langDirectory, "strings_template.pot")))
            {
                PUtil.LogDebug("Morepower language template not found, create one...");
                try
                {
                    Localization.GenerateStringsTemplate(typeof(STRINGS.MOREPOWER), modInfo.langDirectory);
                }
                catch (IOException e)
                {
                    Debug.LogWarning($"{modInfo.assemblyName} Failed to write localization template.");
                    LogExcWarn(e);
                }
            }

            new PPatchManager(harmony).RegisterPatchClass(base.GetType());
            new POptions().RegisterOptions(this, typeof(MorePowerOptions));
        }

        [HarmonyPatch(typeof(GeneratorConfig), nameof(GeneratorConfig.CreateBuildingDef))]
        class Patch_GeneratorConfig_CreateBuildingDef
        {
            public BuildingDef Postfix(ref BuildingDef buildingDef)
            {

                buildingDef.GeneratorWattageRating = MorePowerOptions.Instance.Generator.GeneratorWatt;
                buildingDef.GeneratorBaseCapacity = MorePowerOptions.Instance.Generator.GeneratorCapcityWatt;

                return buildingDef;
            }
        }

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(ManualGeneratorConfig), nameof(ManualGeneratorConfig.CreateBuildingDef))]
        //static BuildingDef ManualGeneratorConfig_CreateBuildingDef_Postfix(ref BuildingDef buildingDef)
        //{
        //    buildingDef.GeneratorWattageRating = MorePowerOptions.Instance.Generator.ManualGeneratorWatt;
        //    buildingDef.GeneratorBaseCapacity = MorePowerOptions.Instance.Generator.ManualGeneratorCapcityWatt;

        //    return buildingDef;
        //}

        /// <summary>
        /// Get max watt defined by user setting
        /// </summary>
        /// <param name="wattageRating">Watt</param>
        /// <returns>float value defined</returns>
        static float GetMaxWattDefined(Wire.WattageRating wattageRating)
        {
            switch (wattageRating)
            {
                case Wire.WattageRating.Max500:     // 500 watt is not used in game code.
                    return 500f;
                case Wire.WattageRating.Max1000:    // Wire Max watt
                    return (float)MorePowerOptions.Instance.Wire.WireMaxWatt;
                case Wire.WattageRating.Max2000:    // Wire Redefined Max watt
                    return (float)MorePowerOptions.Instance.Wire.WireRedefinedMaxWatt;
                case Wire.WattageRating.Max20000:   // Wire High Wattage Max Watt
                    return (float)MorePowerOptions.Instance.Wire.WireHighWattageMaxWatt;
                case Wire.WattageRating.Max50000:   // Wire Redefined High Wattage Max Watt
                    return (float)MorePowerOptions.Instance.Wire.WireRedefinedHighWattageMaxWatt;
                default:
                    return 0f;
            }
        }

        //[HarmonyTranspiler]
        //[HarmonyPatch(typeof(Wire), nameof(Wire.GetMaxWattageAsFloat))]
        //static float Wire_GetMaxWattageAsFloat_Patch(Wire.WattageRating wattageRating)
        //{
        //    return GetMaxWattDefined(wattageRating);
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(PowerTransformerSmallConfig), nameof(PowerTransformerSmallConfig.CreateBuildingDef))]
        //static BuildingDef PowerTransformerSmallConfig_CreateBuildingDef_Patch(ref BuildingDef buildingDef)
        //{
        //    buildingDef.GeneratorWattageRating = (float)MorePowerOptions.Instance.PowerTransformer.PowerTransformerSmallWatt;
        //    return buildingDef;
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(PowerTransformerConfig), nameof(PowerTransformerConfig.CreateBuildingDef))]
        //static BuildingDef PowerTransformerConfig_CreateBuildingDef_Patch(ref BuildingDef buildingDef)
        //{
        //    buildingDef.GeneratorWattageRating = (float)MorePowerOptions.Instance.PowerTransformer.PowerTransformerWatt;
        //    return buildingDef;
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(BatteryConfig), nameof(BatteryConfig.DoPostConfigureComplete))]
        //static void BatteryConfig_DoPostConfigureComplete_Patch(GameObject go)
        //{
        //    go.AddOrGet<Battery>().capacity = (float)MorePowerOptions.Instance.Battery.BatteryCapacity;
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(BatteryMediumConfig), nameof(BatteryMediumConfig.DoPostConfigureComplete))]
        //static void BatteryMediumConfig_DoPostConfigureComplete_Patch(GameObject go)
        //{
        //    go.AddOrGet<Battery>().capacity = (float)MorePowerOptions.Instance.Battery.BatteryMediumCapacity;
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(BatterySmartConfig), nameof(BatterySmartConfig.DoPostConfigureComplete))]
        //static void BatterySmartConfig_DoPostConfigureCompletion_Patch(GameObject go) {
        //    go.AddOrGet<BatterySmart>().capacity = (float)MorePowerOptions.Instance.Battery.BatterySmartCapacity;
        //}
    }
}
