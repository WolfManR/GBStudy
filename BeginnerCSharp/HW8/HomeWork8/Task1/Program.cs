using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using static System.Console;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationManager.OpenMappedExeConfiguration(
                new (){ExeConfigFilename = "App.config"},
                ConfigurationUserLevel.None);
            
            var userInfo = config.GetSection(nameof(UserInfo)) as UserInfo;
            var welcome = string.IsNullOrEmpty(userInfo?.Name) 
                ? config.AppSettings.Settings["Welcome"].Value 
                : $"Welcome {userInfo}";

            WriteLine(welcome);
            
            WriteLine("Enter new name");
            var name = ReadLine();
            WriteLine("Enter new Age");
            var age = ReadLine().AsSpan();
            if (!int.TryParse(age, out var ageNumber))
            {
                WriteLine("Incorrect number");
                return;
            }
            WriteLine("Enter new career");
            var career = ReadLine();

            userInfo ??= new();
            userInfo.Name = name;
            userInfo.Age = ageNumber;
            userInfo.Career = career;
            
            config.Save(ConfigurationSaveMode.Minimal);
            
            // for check that values changes
            // ConfigurationManager.RefreshSection(nameof(userInfo));
            // var result = config.GetSection(nameof(UserInfo));
        }
    }


    public class SectionExtension : ConfigurationSection
    {
        // ReSharper disable once InconsistentNaming
        protected static bool _isReadOnly;
        private new bool IsReadOnly => _isReadOnly;
        private void ThrowIfReadOnly([CallerMemberName] string propertyName = null)
        {
            if (IsReadOnly)
                throw new ConfigurationErrorsException("The property " + propertyName + " is read only.");
        }

        protected void SetWithThrowIfReadOnly<T>(T value, [CallerMemberName] string propertyName = null)
        {
            ThrowIfReadOnly(propertyName);
            this[propertyName] = value;
        }
    }
    

    public sealed class UserInfo : SectionExtension
    {
        // ReSharper disable InconsistentNaming
        
        [ConfigurationProperty(nameof(Name),DefaultValue = "",IsRequired = true)]
        public string Name
        {
            get => (string)this[nameof(Name)];
            set => SetWithThrowIfReadOnly(value);
        }

        [ConfigurationProperty(nameof(Age),DefaultValue = 0,IsRequired = true)]
        [IntegerValidator(MinValue = 0,MaxValue = 140)]
        public int Age
        {
            get => (int)this[nameof(Age)];
            set => SetWithThrowIfReadOnly(value);
        }
        

        [ConfigurationProperty(nameof(Career),DefaultValue = "",IsRequired = false)]
        public string Career
        {
            get => (string)this[nameof(Name)];
            set => SetWithThrowIfReadOnly(value);
        }
        

        // ReSharper restore InconsistentNaming

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => $"{Name} in {Age} age ,with career of {Career}";

        #endregion
    }
}