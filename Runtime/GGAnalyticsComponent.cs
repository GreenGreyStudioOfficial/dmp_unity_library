using UnityEngine;

namespace GreenGrey.Analytics
{
    [DefaultExecutionOrder(-100)]
    public class GGAnalyticsComponent : MonoBehaviour
    {
        private bool m_initialized;
        
        private void Awake ()
        {
            if (!m_initialized) {
                DontDestroyOnLoad (this.gameObject);
                Create();
                Setup();
                m_initialized = true;
            } else {
                Destroy (this.gameObject);
            }
        }

        private void Create()
        {
            GGAnalytics.Instance.Create(gameObject);
        }
        
        private void Setup()
        {
            var configuration = gameObject.GetComponent<GGAnalyticsConfiguration>();
            if (configuration == null)
                return;
            
            GGAnalytics.Instance.Setup(configuration);
        }
    }
}