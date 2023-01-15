using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Primitives/String event channel")]
    public class StringEventChannelSO : EventChannelSO
    {
        public UnityAction<string> OnEventRaised;

        public void RaiseEvent(string text)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(text);
        }
    }
}
