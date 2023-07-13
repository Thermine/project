using UnityEngine;
using UnityEngine.UI;

namespace Fikus.TrappedInASnowStorm.Assets.ProjectFiles.Scripts.Managers
{
	public class FishingManager : MonoBehaviour
	{
		// GameObjects

		public GameObject Player;
		public GameObject Text;
		public Slider sliderFish;

		[SerializeField] private GameObject fishingRod;
		[SerializeField] private GameObject catchedFish;
		[SerializeField] private GameObject fish;

		// Booleans

		private bool onTrigger;

		private bool isFishCatched = false;


		void Update()
		{
			if (onTrigger == true)
			{
				if (Input.GetKey(KeyCode.E) && isFishCatched == false)
				{

					sliderFish.gameObject.SetActive(true);
					sliderFish.value += 0.2f;
					if (sliderFish.value >= 100)
					{
						Player.GetComponent<FishingManagerUI>().fish += 1;
						sliderFish.value = 0;
						sliderFish.gameObject.SetActive(false);
						isFishCatched = true;
						Text.SetActive(false);
						fish.SetActive(false);
						catchedFish.SetActive(true);
					}
				}
				else
				{
					sliderFish.value = 0;
					sliderFish.gameObject.SetActive(false);
				}
			}
		}
		void OnTriggerStay(Collider col)
		{
			if (col.tag == "Player")
			{
				if (isFishCatched == false)
				{
					Text.SetActive(true);

				}

				onTrigger = true;
				fishingRod.SetActive(true);
			}
		}
		void OnTriggerExit(Collider col)
		{
			if (col.tag == "Player")
			{
				Text.SetActive(false);
				onTrigger = false;
				fishingRod.SetActive(false);
			}
		}
	}
}