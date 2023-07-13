using UnityEngine;
using UnityEngine.UI;

namespace Fikus.TrappedInASnowStorm.Assets.ProjectFiles.Scripts.Managers
{
	public class FishingManagerUI : MonoBehaviour
	{
		public int fish; // fishes count
		public Text txt; // UI text

		void Update()
		{
			txt.text = "Рыбки: " + fish;
		}
	}

}