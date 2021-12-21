using ISynergy.Framework.Core.Abstractions;
using ISynergy.Framework.Core.Base;
using ISynergy.Framework.Core.Enumerations;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SyncDemo
{
    public class Context : ObservableClass, IContext
    {
        private static IContext _context;

        public ObservableCollection<IProfile> Profiles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IProfile CurrentProfile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TimeZoneInfo CurrentTimeZone => throw new NotImplementedException();

        public NumberFormatInfo NumberFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SoftwareEnvironments Environment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool NormalScreen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CurrencySymbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CurrencyCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsAuthenticated => throw new NotImplementedException();

        public bool IsUserAdministrator => throw new NotImplementedException();

        public bool IsSynchronizationEnabled
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public bool IsOffline
        {
            get => GetValue<bool>();
            set => SetValue(value, true);
        }
        public List<Type> ViewModels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Context()
        {
            IsOffline = false;
        }

        public static IContext GetInstance()
        {
            if (_context == null)
                _context = new Context();

            return _context;
        }
    }
}
