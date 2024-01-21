using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSerialization;
using UnityEngine;
using System.Reflection;
using System.ComponentModel;
using STRINGS;

namespace AdjustableSweeper
{
    [SerializationConfig(MemberSerialization.OptIn)]
    public class SweeperRangeAdjust: KMonoBehaviour, IUserControlledCapacity
    {
        private static readonly EventSystem.IntraObjectHandler<SweeperRangeAdjust> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<SweeperRangeAdjust>(OnCopySettings);

        private static void OnCopySettings(SweeperRangeAdjust comp, object data)
        {
            comp.OnCopySettings((GameObject)data);
        }

        private void OnCopySettings(GameObject go)
        {
            SweeperRangeAdjust sweeperRange = go.GetComponent<SweeperRangeAdjust>();
            if (sweeperRange != null)
            {
                this.range = sweeperRange.range;
            }
        }

        [MyCmpReq]
        public SolidTransferArm solidTransferArm;

        [MyCmpReq]
        public RangeVisualizer rangeVisualizer;

        static readonly FieldInfo solidTransferArm_choreConsumer = typeof(SolidTransferArm).GetField("choreConsumer", BindingFlags.Instance | BindingFlags.NonPublic);

        private ChoreConsumer choreConsumer;

        public ChoreConsumer ChoreConsumer
        {
            get
            {
                if (solidTransferArm == null) solidTransferArm = GameObject.FindObjectOfType<SolidTransferArm>();
                if (choreConsumer == null) choreConsumer = (ChoreConsumer)solidTransferArm_choreConsumer.GetValue(solidTransferArm);
                return choreConsumer;
            }
        }

        [Serialize]
        private int range = 0;

        public const int maxRange = 16;
        public const int minRange = 1;

        public const string KEY = "STRINGS.UI.UISIDESCREENS.SWEEPERRANGEADJUST";

        public float UserMaxCapacity
        {
            get
            {
                return (float)range;
            }
            set { range = (int)value; }
        }

        public float MaxCapacity
        {
            get
            {
                return (float)maxRange;
            }
        }

        public float MinCapacity
        {
            get
            {
                return (float)minRange;
            }
        }

        public float AmountStored
        {
            get
            {
                return this.UserMaxCapacity;
            }
        }

        public bool WholeValues
        {
            get { return true; }
        }

        public LocString CapacityUnits => UI.UNITSUFFIXES.TILES;

        public int SliderDecimalPlaces(int i)
        {
            return 8;
        }

        public float GetSliderValue(int i)
        {
            return range;
        }

        public string GetSliderTooltipKey(int i)
        {
            return KEY + ".TOOLTIP";
        }

        public string GetSliderTooltip()
        {
            return string.Format(STRINGS.UI.UISIDESCREENS.SWEEPERRANGEADJUST.TOOLTIP, range, UI.UNITSUFFIXES.TILES);
        }

        public string SliderTitleKey => KEY + ".TITLE";
        public string SliderUnits => UI.UNITSUFFIXES.TILES;

        public void SetSliderValue(float val, int i)
        {
            range = (int)val;
            Update();
        }

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            Subscribe<SweeperRangeAdjust>((int)GameHashes.CopySettings, OnCopySettingsDelegate);
        }

        protected override void OnSpawn()
        {
            if (range == 0)
            {
                range = solidTransferArm.pickupRange;
            }
            Update();
        }

        private void Update()
        {
            solidTransferArm.pickupRange = range;
            rangeVisualizer.RangeMax.x = rangeVisualizer.RangeMax.y = range;
            rangeVisualizer.RangeMin.x = rangeVisualizer.RangeMin.y = -range;

            ChoreConsumer.SetReach(range);
        }
    }
}
