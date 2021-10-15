using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Code
{
    public class FakePreferenceRepository : IPreferenceRepository
    {

        public const string PREFERENCE_PROJECT_ID = "Project_Id";
        public const string PREFERENCE_PROJECT_NAME = "Project_Name";
        private const string NO_ERROR = "";

        Dictionary<string, Dictionary<string, string>> Preferences = new Dictionary<string, Dictionary<string, string>>();

        
        public string GetPreference(string UserName, string PreferenceName)
        {
            Dictionary<string, string> NameValuePair = new Dictionary<string, string>();
            string value = "";
            if(Preferences.TryGetValue(UserName, out NameValuePair))
            {
                NameValuePair.TryGetValue(PreferenceName, out value);
            }
            return value;
        }
        public string SetPreference(string UserName, string PreferenceName, string Value)
        {
            Preferences[UserName][PreferenceName] = Value;
            return NO_ERROR;
        }
    }
}
