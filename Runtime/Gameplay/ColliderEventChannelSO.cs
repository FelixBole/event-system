using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Collider Event Channel")]
    public class ColliderEventChannelSO : EventChannelSO
    {
        public UnityAction<Collider> OnEventRaised;

        public void RaiseEvent(Collider collider)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(collider);
        }
    }

}