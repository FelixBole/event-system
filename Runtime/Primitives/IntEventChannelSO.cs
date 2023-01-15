using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Primitives/Int Event Channel")]
    public class IntEventChannelSO : EventChannelSO
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int x)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(x);
        }
    }
}
