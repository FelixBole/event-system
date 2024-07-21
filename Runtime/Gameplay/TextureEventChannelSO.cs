using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Texture Event Channel")]
    public class TextureEventChannelSO : EventChannelSO
    {
        public UnityAction<Texture> OnEventRaised;

        public void RaiseEvent(Texture texture)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(texture);
        }
    }

}