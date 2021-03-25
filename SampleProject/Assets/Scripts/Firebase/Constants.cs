using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapName
{
    private MapName(string value) { Value = value; }

    public string Value { get; set; }

    public static MapName MemoryMall { get { return new MapName("Memory Mall"); } }
    public static MapName BounceHouse { get { return new MapName("Bounce House"); } }
    public static MapName Pub { get { return new MapName("Pub"); } }
    public static MapName GreekRow { get { return new MapName("Greek Row"); } }
    public static MapName CB2 { get { return new MapName("CB2"); } }
    public static MapName StudentUnion { get { return new MapName("Student Union"); } }
}
