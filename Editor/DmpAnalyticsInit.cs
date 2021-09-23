using GreenGrey.Dmp;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenGrey.Editor
{
    public class DmpAnalyticsInit
    {
        [MenuItem("Edit/GreenGrey/Create Dmp Prefab")]
        public static void CreateDmpAnalyticsPrefabOnScene()
        {
            var dmpObject = new GameObject("DmpAnalytics");
            dmpObject.AddComponent<DmpConfiguration>();
            dmpObject.AddComponent<DmpAnalytics>();
            SceneManager.MoveGameObjectToScene(dmpObject, SceneManager.GetActiveScene());
        }
    }
}