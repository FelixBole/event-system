using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/Scene Event Channel")]
    public class SceneEventChannelSO : EventChannelSO
    {
        public UnityAction<Scene> OnEventRaised;

        public void RaiseEvent(Scene scene)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(scene);
        }
    }

}