using GreenGrey.Dmp;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenGrey.Editor
{
    public class DmpAnalyticsInit
    {
        [MenuItem("GreenGrey/Analytics/Create GGAnalytics GameObject")]
        public static void CreateGGAnalyticsPrefabOnScene()
        {
            var dmpObject = new GameObject("GGAnalytics");
            dmpObject.AddComponent<DmpConfiguration>();
            dmpObject.AddComponent<DmpAnalytics>();
            SceneManager.MoveGameObjectToScene(dmpObject, SceneManager.GetActiveScene());
        }
    }
}