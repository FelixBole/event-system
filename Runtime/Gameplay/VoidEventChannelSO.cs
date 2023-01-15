using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Void Event Channel")]
    public class VoidEventChannelSO : EventChannelSO
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }
    }
}
