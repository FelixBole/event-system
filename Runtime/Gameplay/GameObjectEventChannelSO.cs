using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/GameObject Event Channel")]
    public class GameObjectEventChannelSO : EventChannelSO
    {
        public UnityAction<GameObject> OnEventRaised;
        public void RaiseEvent(GameObject value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}