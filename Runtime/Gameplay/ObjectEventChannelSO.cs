using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Object Event Channel")]
    public class ObjectEventChannelSO : EventChannelSO
    {
        public UnityAction<Object> OnEventRaised;

        public void RaiseEvent(Object obj)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(obj);
        }
    }

}