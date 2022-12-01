using System;
using UnityEngine;

namespace GreenGrey.Analytics.Helpers
{
    internal sealed class ProxyHolder : MonoBehaviour
    {
        private IJsonProxy m_jsonProxy;

        private void Awake()
        {
            m_jsonProxy = new NewtonsoftProxy();
        }
    }
}
