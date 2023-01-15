using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Vector2 Event Channel")]
    public class Vector2EventChannelSO : EventChannelSO
    {
        public UnityAction<Vector2> OnEventRaised;

        public void RaiseEvent(Vector2 value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}
