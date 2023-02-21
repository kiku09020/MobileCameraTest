using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways,RequireComponent(typeof(RectTransform))]
public class SetSafeArea : MonoBehaviour
{
	RectTransform rect;

    private void Start()
    {
		rect = GetComponent<RectTransform>();
	}

	private void Update()
	{
		if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Handheld) {
			var area = Screen.safeArea;
			var resolution = Screen.currentResolution;

			rect.sizeDelta = Vector2.zero;
			rect.anchorMin = new Vector2(area.xMin / resolution.width, area.yMin / resolution.height);
			rect.anchorMax = new Vector2(area.xMax / resolution.width, area.yMax / resolution.height);
		}

		else {
			rect.anchorMin = Vector2.zero;
			rect.anchorMax = Vector2.one;
		}
	}
}
