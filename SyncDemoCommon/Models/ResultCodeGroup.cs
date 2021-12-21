using ISynergy.Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SyncDemoCommon.Models {
  public class ResultCodeGroup : ModelBase {
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
        /// Default constructor.
        /// </summary>
        public ResultCodeGroup()
        {
            ResultCodeGroupId = Guid.NewGuid();
        }
    }
}
