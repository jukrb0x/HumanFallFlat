using System.Collections;
using UnityEngine;

public class MacXmasOptimizer : MonoBehaviour
{
	public Light[] problematicLights;

	private void Start()
	{
		StartCoroutine(DisableLights());
	}

	private IEnumerator DisableLights()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		Light[] array = problematicLights;
		foreach (Light light in array)
		{
			light.enabled = false;
		}
	}
}
