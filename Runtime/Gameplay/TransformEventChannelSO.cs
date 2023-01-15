using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Transform Event Channel")]
    public class TransformEventChannelSO : EventChannelSO
    {
        public UnityAction<Transform> OnEventRaised;

        public void RaiseEvent(Transform value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}
