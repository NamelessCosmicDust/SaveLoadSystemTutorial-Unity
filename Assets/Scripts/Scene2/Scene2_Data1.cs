using System;
using System.Collections.Generic;

/// <summary>
/// This class acts as a container to pass a set of data around as single packaged data.
/// </summary>
[Serializable]
internal class Scene2_Data1
{
    public List<int> intData;
    public List<string> stringData;
    public List<bool> boolData;

    // Contructor
    public Scene2_Data1(
        List<int> intData = null,
        List<string> stringData = null,
        List<bool> boolData = null
        )
    {
        this.intData = intData ?? new();
        this.stringData = stringData ?? new();
        this.boolData = boolData ?? new();
    }
}
