using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Quaternion Event Channel")]
    public class QuaternionEventChannelSO : EventChannelSO
    {
        public UnityAction<Quaternion> OnEventRaised;

        public void RaiseEvent(Quaternion quaternion)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(quaternion);
        }
    }

}