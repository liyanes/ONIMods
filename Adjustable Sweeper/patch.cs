using HarmonyLib;
using KMod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AdjustableSweeper
{
    internal class Mod: UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            LocString.CreateLocStringKeys(typeof(STRINGS.UI), "STRINGS.");
        }

        [HarmonyPatch(typeof(SolidTransferArmConfig), nameof(SolidTransferArmConfig.ConfigureBuildingTemplate))]
        private static class Patch_SolidTransferArmConfig_ConfigureBuildingTemplate
        {
            static void Postfix(GameObject go, Tag prefab_tag)
            {
                go.AddOrGet<SweeperRangeAdjust>();
            }
        }
    }
}
