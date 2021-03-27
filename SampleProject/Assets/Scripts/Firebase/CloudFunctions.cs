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

    public static Task<string> SetHighestWave(int wave)
    {
        // Create the arguments to the callable function.
        var data = new Dictionary<string, object>();
        data["highestWave"] = wave;
        // Call the function and extract the operation from the result.
        var function = CloudFunctions.functions.GetHttpsCallable("setHighestWave");
        return function.CallAsync(data).ContinueWith((task) =>
        {
            return "Done";
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
            return "Done";
        });
    }

    public static Task SyncUser()
    {
        var function = CloudFunctions.functions.GetHttpsCallable("unlockMap");
        return function.CallAsync().ContinueWith((task) =>
        {
            Debug.Log(task.Result);
            return;
        });
    }

}
