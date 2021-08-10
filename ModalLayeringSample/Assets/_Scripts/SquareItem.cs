using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleModalLayer
{
    public class SquareItem : MonoBehaviour
    {
        public enum LocationCreated //TODO: Better name?
        {
            homeView = 0,
            backpackModal = 1
        }

        [SerializeField]
        private Button button = default;
        [SerializeField]
        private Image itemImage = default;
        [SerializeField]
        private RectTransform amountPanel = default;
        [SerializeField]
        private TextMeshProUGUI amountText = default; // Amount owned

        private AppManager appMan = default;
        private Item mItem = default;
        private LocationCreated mLocationCreated = default;

        public void Setup(Item item, LocationCreated locationCreated)
        {
            appMan = AppManager.Instance;
            mItem = item;
            mLocationCreated = locationCreated;

            itemImage.sprite = appMan.AppDataObject.GetItemIconByItemType(mItem.type);

            amountPanel.gameObject.SetActive(mItem.totalOwned > 1);
            if (amountPanel.gameObject.activeSelf)
            {
                amountText.text = mItem.totalOwned.ToString();
            }

            button.onClick.AddListener(OpenInfoPopupCallback);
        }

        public void OpenInfoPopupCallback()
        {
            //Create an info modal for the item
            MessageBox.CreateInfoModal(item: mItem, locationCreated: mLocationCreated);
        }

        public void Shutdown()
        {
            button.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}