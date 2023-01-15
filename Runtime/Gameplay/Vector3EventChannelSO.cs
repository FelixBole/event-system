using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Vector3 Event Channel")]
    public class Vector3EventChannelSO : EventChannelSO
    {
        public UnityAction<Vector3> OnEventRaised;

        public void RaiseEvent(Vector3 value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}
