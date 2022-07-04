using System.Linq;
using GreenGrey.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenGrey.Editor
{
    public class GGAnalyticsInit
    {
        [MenuItem("GreenGrey/Analytics/Create GGAnalytics GameObject")]
        public static void CreateGGAnalyticsPrefabOnScene()
        {
            CreateAndAddGameObjectToScene();
        }
        
        [MenuItem("GreenGrey/Analytics/Create GGAnalytics with configuration")]
        public static void CreateGGAnalyticsConfigurationOnScene()
        {
            var rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            var ggAnalyticsObject = rootGameObjects.FirstOrDefault(_go => _go.name.Equals("GGAnalytics"));
            if (ggAnalyticsObject == null)
                ggAnalyticsObject = CreateAndAddGameObjectToScene();
            
            ggAnalyticsObject.AddComponent<GGAnalyticsConfiguration>();
        }

        private static GameObject CreateAndAddGameObjectToScene()
        {
            var ggAnalyticsObject = new GameObject("GGAnalytics");
            ggAnalyticsObject.AddComponent<GGAnalyticsComponent>();
            SceneManager.MoveGameObjectToScene(ggAnalyticsObject, SceneManager.GetActiveScene());
            return ggAnalyticsObject;
        }
    }
}