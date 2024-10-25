
using System.Linq;

internal class Scene2_DataCollector
{
    private readonly Scene2_Manager scene2_Manager;

    internal Scene2_DataCollector()
    {
        scene2_Manager = UniqueObjectLocator.GetObjectLocation<Scene2_Manager>();
    }

    // Proprty getters must return null if its customer is not active.
    internal Scene2_Data1 Data1
    {
        get
        {
            // Example: Data validation for values
            //if (scene2_Manager)
            //{
            //    scene2_Manager.data1.intData =
            //         scene2_Manager.data1.intData.
            //         Select(x => x > 100 ? 100 : x).ToList();
                
            //    return scene2_Manager.data1;
            //}

            if (scene2_Manager) return scene2_Manager.data1;
            else return null;
        }
        set
        {
            if (scene2_Manager) scene2_Manager.data1 = value;
        }
    }

}