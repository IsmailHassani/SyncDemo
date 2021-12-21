using ISynergy.Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SyncDemoCommon.Models {
  public class Tester : ModelBase {
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
        /// Gets or sets the SerialNumber property value.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string SerialNumber {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Tester()
        {
            TesterId = Guid.NewGuid();
        }
    }
}
