using UnityEngine;
using System.Collections;
using System;

namespace Reflections_Plugin
{
	public class ReflectionUpdate : MonoBehaviour
	{
		public int seconds, texture_resolution;
		// Use this for initialization
		void Start()
		{
			StartCoroutine(Render());
			foreach (ReflectionProbe temp in gameObject.transform.GetComponentsInChildren<ReflectionProbe>())
			{
				temp.RenderProbe();
			}
		}
		IEnumerator Render()
		{
			yield return new WaitForSeconds(60);
			while (true)
			{
				seconds = int.Parse(Reflections_Plugin.UpdateSlider.GetValue().ToString());
				texture_resolution = int.Parse(Reflections_Plugin.TextureSlider.GetValue().ToString());
				yield return new WaitForSeconds(seconds);
				foreach (ReflectionProbe temp in gameObject.transform.GetComponentsInChildren<ReflectionProbe>())
				{
					temp.resolution = Convert.ToInt32(Math.Pow(2, 3 + texture_resolution));
						temp.RenderProbe();
					//yield return new WaitForSeconds(0.5f);
				}
			}
		}
	}
}
