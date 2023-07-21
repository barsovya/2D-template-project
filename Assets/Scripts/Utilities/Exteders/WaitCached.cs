using UnityEngine;
using System.Collections.Generic;

public static class WaitCached
{
	private static Dictionary<float, WaitForSeconds> _waiters = new Dictionary<float, WaitForSeconds>(100);

	private static Dictionary<float, WaitForSecondsRealtime> _waitersRealtime =
		new Dictionary<float, WaitForSecondsRealtime>(100);

	private static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();

	public static WaitForEndOfFrame EndOfFrame
	{
		get { return _endOfFrame; }
	}

	private static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

	public static WaitForFixedUpdate FixedUpdate
	{
		get { return _fixedUpdate; }
	}

	public static WaitForSeconds WaitForSeconds(float seconds)
	{
		if (!_waiters.ContainsKey(seconds))
			_waiters.Add(seconds, new WaitForSeconds(seconds));
		return _waiters[seconds];
	}

	public static WaitForSecondsRealtime WaitForSecondsRealtime(float seconds)
	{
		if (!_waitersRealtime.ContainsKey(seconds))
			_waitersRealtime.Add(seconds, new WaitForSecondsRealtime(seconds));
		return _waitersRealtime[seconds];
	}
}