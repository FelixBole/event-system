using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Rigidbody Event Channel")]
    public class RigidbodyEventChannelSO : EventChannelSO
    {
        public UnityAction<Rigidbody> OnEventRaised;

        public void RaiseEvent(Rigidbody rb)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(rb);
        }
    }

}