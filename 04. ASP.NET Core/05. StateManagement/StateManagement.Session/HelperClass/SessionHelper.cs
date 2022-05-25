using Newtonsoft.Json;

namespace StateManagement.Session.HelperClass;

public static class SessionHelper
{
    public static T Get<T>(this ISession session,string key)
    {
       var serializedObject =  session.GetString(key);
       if(!string.IsNullOrEmpty(serializedObject))
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }
       return default(T);

    }

    public static void Set<T>(this ISession session, string key, T input)
    {
        var serializedObject = JsonConvert.SerializeObject(input);
        session.SetString(key, serializedObject);
    }
}
