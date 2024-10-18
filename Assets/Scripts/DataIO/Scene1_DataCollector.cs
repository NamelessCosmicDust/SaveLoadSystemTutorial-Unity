using System.Collections.Generic;

internal class Scene1_DataCollector
{
    private readonly Scene1_Manager scene1_Manager;

    internal Scene1_DataCollector()
    {
        scene1_Manager = UniqueObjectLocator.GetObjectLocation<Scene1_Manager>();
    }

    // Proprty getters must return null if its customer is not active.
    internal List<int> Data1_Int
    {
        get
        {
            if (scene1_Manager) return scene1_Manager.intData;
            else return null;
        }
        set { if (scene1_Manager) scene1_Manager.intData = value; }
    }
    internal List<string> Data1_String
    {
        get
        {
            if (scene1_Manager) return scene1_Manager.stringData;
            else return null;
        }
        set { if (scene1_Manager) scene1_Manager.stringData = value; }
    }
    internal List<bool> Data1_Bool
    {
        get
        {
            if (scene1_Manager) return scene1_Manager.boolData;
            else return null;
        }
        set { if (scene1_Manager) scene1_Manager.boolData = value; }
    }


}