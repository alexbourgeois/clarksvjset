using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAPPS {
	public class ChillhedronController : MonoBehaviour
	{
		
		public KAPPS kappsDaddy;
		private List<KAPPSSource> orbChilldrenSources = new List<KAPPSSource>();
		
		public float chillOrbRadius = 10.0f;
		public float chillOrbSigma = 1.0f;
		public float chillOrbIntensity = -10.0f;
		public float viscExtra = 0.0f;
		public float gridStrengthPercentage = 10.0f;
		
		// Start is called before the first frame update
		void Start()
		{
			int babiez = this.gameObject.transform.childCount;
			for (int i = 0; i < babiez; i++)
            {
				GameObject babe = this.gameObject.transform.GetChild(i).gameObject;
				KAPPSSource babeSource = (KAPPSSource) babe.GetComponent<KAPPSSource>();
				if (babeSource.updater == KAPPSSource.Updater.Orb) {
					orbChilldrenSources.Add(babeSource);
				}
			}
			Debug.Log(orbChilldrenSources.Count + " orb babes found.");
		}

		// Update is called once per frame
		void Update()
		{
			// Le dady properties
			kappsDaddy._particleUpdateDeceleration = 1 + 0.01f * viscExtra;
			kappsDaddy._gridStrength = gridStrengthPercentage * 0.01f;
			
			// All babes properties
			for (int i = 0; i < orbChilldrenSources.Count; i++)
            {
                if (orbChilldrenSources[i] == null)
                {
                    Debug.LogWarning("Miaou");
                    continue;
                }
				
				orbChilldrenSources[i].orbRadius = chillOrbRadius;
				orbChilldrenSources[i].orbSigma = Mathf.Abs(chillOrbSigma);
				orbChilldrenSources[i].intensity = chillOrbIntensity;
			}
		}
	}

}
