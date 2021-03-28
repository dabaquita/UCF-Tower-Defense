using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Functions;


public class CloudFunctions : MonoBehaviour
{

    public static FirebaseFunctions functions = FirebaseFunctions.DefaultInstance;

    static User decodeUser(Dictionary<object,object> dict) {

        string username = null;
        int currentLevel = -1;
        int highestWave = -1;
        Dictionary<string, bool> unlockedMaps = null;
        int xp = -1;
        foreach (KeyValuePair<object, object> kvp in dict) {
            var val = kvp.Value;
            switch ((string)kvp.Key) {
                case "username":
                    username = (val is string) ? (string)val : null;
                    break;
                case "currentLevel":
                    Debug.Log($"CURRENT: {val.GetType().ToString()} {val is float}");
                    currentLevel = (val is Int64) ? Convert.ToInt32((Int64)val) : -1;
                    break;
                case "highestWave":
                Debug.Log($"CURRENT: {val.GetType().ToString()} {val is int}");
                    highestWave = (val is Int64) ? Convert.ToInt32((Int64)val) : -1;
                    break;
                case "unlockedMaps":
                    if (val is Dictionary<object, object>) {
                        unlockedMaps = decodeUnlocks((Dictionary<object, object>)val);
                    }
                    break;
                case "xp":
                Debug.Log($"CURRENT: {val.GetType().ToString()} {val is int}");
                    xp = (val is Int64) ? Convert.ToInt32((Int64)val) : -1;
                    break;
                default:
                    break;
            }
        }

        if (username == null) {
            Debug.Log("Couldn't decode username");
            return null;
        }else if (currentLevel == -1) {
            Debug.Log("Couldn't decode currentLevel");
            return null;
        }else if (highestWave == -1) {
            Debug.Log("Couldn't decode highestwave");
            return null;
        }else if (unlockedMaps == null) {
            Debug.Log("Couldn't decode unlocked maps");
            return null;
        }else if (xp == -1) {
            Debug.Log("Couldn't decode xp");
            return null;
        }

        return new User(username, currentLevel, highestWave, unlockedMaps, xp);
    }


    static Dictionary<string,bool> decodeUnlocks(Dictionary<object, object> dict) {
        Dictionary<string, bool> unlockedMaps = new Dictionary<string, bool>();
         foreach (KeyValuePair<object, object> kvp in dict) {
            if (kvp.Value is bool) {
                unlockedMaps[(string)kvp.Key] = (bool)kvp.Value;
            }
         }
         return unlockedMaps;
    }

    static void updateUser(Task<HttpsCallableResult> task) {
        if (!task.IsFaulted) {
            var dict = (Dictionary<object,object>)task.Result.Data;
                
            var user = decodeUser(dict);
            if (user != null) {
                AuthManager.currentUser = user;
            }else{
                Debug.Log("User was null");
            }
        }else{
            Debug.Log("IsFaulted");
        }
    }

    public static Task<string> SetHighestWave(int wave)
    {
        // Create the arguments to the callable function.
        var data = new Dictionary<string, object>();
        data["highestWave"] = wave;
        // Call the function and extract the operation from the result.
        var function = CloudFunctions.functions.GetHttpsCallable("setHighestWave");
        return function.CallAsync(data).ContinueWith((task) =>
        {
            updateUser((Task<HttpsCallableResult>)task);
            return "";
        });
    }



    public static Task<string> UnlockMap(MapName name)
    {
        // Create the arguments to the callable function.
        var data = new Dictionary<string, object>();
        data["mapName"] = name.Value;
        // Call the function and extract the operation from the result.
        var function = CloudFunctions.functions.GetHttpsCallable("unlockMap");
        return function.CallAsync(data).ContinueWith((task) =>
        {
            updateUser((Task<HttpsCallableResult>)task);
            return "";
        });
    }

    public static Task<string> addXP(int xp)
    {
        // Create the arguments to the callable function.
        var data = new Dictionary<string, object>();
        data["xp"] = xp;
        // Call the function and extract the operation from the result.
        var function = CloudFunctions.functions.GetHttpsCallable("getUserData");
        return function.CallAsync(data).ContinueWith((task) =>
        {
            updateUser((Task<HttpsCallableResult>)task);
            return "";
        });
    }


    //The firesbase SDK will call this method and insert the authentication
    // details, which the cloud function will decode which user is
    // calling it so it knows which user data to return
    public static Task SyncUser()
    {
        var function = CloudFunctions.functions.GetHttpsCallable("getUserData");
        return function.CallAsync().ContinueWith((task) =>
        {
            updateUser((Task<HttpsCallableResult>)task);
            return "";
        });
    }

}
