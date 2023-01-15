using UnityEngine.Events;
using UnityEngine;

namespace Slax.EventSystem
{
	[CreateAssetMenu(menuName = "Events/Primitives/Bool Event Channel")]
	public class BoolEventChannelSO : EventChannelSO
	{
		public UnityAction<bool> OnEventRaised;
		public void RaiseEvent(bool value)
		{
			if (OnEventRaised != null)
				OnEventRaised.Invoke(value);
		}
		public void UnsubscribeAll()
		{
			if (OnEventRaised != null)
			{
				if (OnEventRaised.GetInvocationList() != null)
				
					foreach (System.Delegate d in OnEventRaised.GetInvocationList())
					{
						OnEventRaised -= d as UnityAction<bool>;

					}
			}
		}
	}
}