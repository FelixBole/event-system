using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/MonoBehaviour Event Channel")]
    public class MonoBehaviourEventChannelSO : EventChannelSO
    {
        public UnityAction<MonoBehaviour> OnEventRaised;

        public void RaiseEvent(MonoBehaviour mono)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(mono);
        }
    }

}