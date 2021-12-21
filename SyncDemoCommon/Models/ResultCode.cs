using ISynergy.Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SyncDemoCommon.Models {
  public class ResultCode : ModelBase {
        /// <summary>
        /// Gets or sets the ResultCodeId property value.
        /// </summary>
        [Required]
        public Guid ResultCodeId {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ResultCodeGroupId property value.
        /// </summary>
        [Required]
        public Guid ResultCodeGroupId {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the TesterId property value.
        /// </summary>
        [Required]
        public Guid TesterId {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Description property value.
        /// </summary>
        [Required]
        public string Description {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Number property value.
        /// </summary>
        [Required]
        public int Number {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the IsPercentage property value.
        /// </summary>
        public bool IsPercentage {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Action property value.
        /// </summary>
        public short Action {
            get => GetValue<short>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Index property value.
        /// </summary>
        public long Index {
            get => GetValue<long>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the IsAutogradePercentage property value.
        /// </summary>
        public bool IsAutogradePercentage {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the AutogradeScript property value.
        /// </summary>
        public byte[] AutogradeScript {
            get => GetValue<byte[]>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the StagePosition property value.
        /// </summary>
        public int StagePosition {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the CameraParameters property value.
        /// </summary>
        public byte[] CameraParameters {
            get => GetValue<byte[]>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ResultCodeIndex property value.
        /// </summary>
        public short ResultCodeIndex {
            get => GetValue<short>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Threshold property value.
        /// </summary>
        public float Threshold {
            get => GetValue<float>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the KeyIndex property value.
        /// </summary>
        public int KeyIndex {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ResultCode()
        {
            ResultCodeId = Guid.NewGuid();
        }
    }
}
