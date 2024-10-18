using System;
using System.Collections.Generic;

/// <summary>
/// This class acts as a data warehouse. DataIO only needs to know about this class.
/// </summary>
[Serializable]
internal class DataGetSet
{
    private readonly Scene1_DataCollector scene1_DataCollector = new();
    public List<int> scene1_IntData;
    public List<string> scene1_StringData;
    public List<bool> scene1_BoolData;

    private readonly Scene2_DataCollector scene2_DataCollector = new();
    public Scene2_Data1 scene2_Data1;

    // Add more...


    internal void GetData()
    {
        scene1_IntData = scene1_DataCollector.Data1_Int;
        scene1_StringData = scene1_DataCollector.Data1_String;
        scene1_BoolData = scene1_DataCollector.Data1_Bool;

        scene2_Data1 = scene2_DataCollector.Data1;

        // Add more...
    }

    internal void SetData()
    {
        scene1_DataCollector.Data1_Int = scene1_IntData;
        scene1_DataCollector.Data1_String = scene1_StringData;
        scene1_DataCollector.Data1_Bool = scene1_BoolData;

        scene2_DataCollector.Data1 = scene2_Data1;

        // Add more...
    }

}
