using UnityEngine;
using UnityEngine.Events;

namespace Slax.EventSystem
{
    [CreateAssetMenu(menuName = "Events/Gameplay/ScriptableObject Event Channel")]
    public class ScriptableObjectEventChannelSO : EventChannelSO
    {
        public UnityAction<ScriptableObject> OnEventRaised;

        public void RaiseEvent(ScriptableObject scriptableObject)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(scriptableObject);
        }
    }

}