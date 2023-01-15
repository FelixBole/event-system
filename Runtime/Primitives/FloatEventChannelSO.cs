using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Primitives/Float Event Channel")]
    public class FloatEventChannelSO : EventChannelSO
    {
        public UnityAction<float> OnEventRaised;
        public void RaiseEvent(float value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}