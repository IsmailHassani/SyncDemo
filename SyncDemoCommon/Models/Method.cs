using ISynergy.Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SyncDemoCommon.Models {
  public class Method : ModelBase {
        /// <summary>
        /// Gets or sets the MethodId property value.
        /// </summary>
        [Required]
        public Guid MethodId {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ResultCodeGroupId property value.
        /// </summary>
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
        /// Gets or sets the Number property value.
        /// </summary>
        [Required]
        public int Number {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Name property value.
        /// </summary>
        [Required]
        public string Name {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Type property value.
        /// </summary>
        [MaxLength(100)]
        public string Type {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the IsDestructive property value.
        /// </summary>
        public bool IsDestructive {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the IsAutoResultCode property value.
        /// </summary>
        public bool IsAutoResultCode {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ResultCodeIndex property value.
        /// </summary>
        public long ResultCodeIndex {
            get => GetValue<long>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the CreationDate property value.
        /// </summary>
        public int CreationDate {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the CreationTime property value.
        /// </summary>
        public int CreationTime {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ModificationDate property value.
        /// </summary>
        public int ModificationDate {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the ModificationTime property value.
        /// </summary>
        public int ModificationTime {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the UserHistoryNumber property value.
        /// </summary>
        public int UserHistoryNumber {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the Data property value.
        /// </summary>
        public byte[] Data {
            get => GetValue<byte[]>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the SensorMaximumForceRange property value.
        /// </summary>
        public float SensorMaximumForceRange {
            get => GetValue<float>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the IsAutomationMethod property value.
        /// </summary>
        public bool IsAutomationMethod {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the FormNumber property value.
        /// </summary>
        public int FormNumber {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the OrderNumber property value.
        /// </summary>
        public int OrderNumber {
            get => GetValue<int>();
            set => SetValue(value);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Method()
        {
            MethodId = Guid.NewGuid();
        }
    }
}
