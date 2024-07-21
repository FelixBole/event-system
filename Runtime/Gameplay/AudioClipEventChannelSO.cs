using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Audio Clip Event Channel")]
    public class AudioClipEventChannelSO : EventChannelSO
    {
        public UnityAction<AudioClip> OnEventRaised;

        public void RaiseEvent(AudioClip clip)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(clip);
        }
    }

}