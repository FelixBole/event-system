using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Sprite Event Channel")]
    public class SpriteEventChannelSO : EventChannelSO
    {
        public UnityAction<Sprite> OnEventRaised;

        public void RaiseEvent(Sprite sprite)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(sprite);
        }
    }

}