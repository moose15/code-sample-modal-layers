using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CodeSampleModalLayer
{
    public class BackpackModal : MonoBehaviour, IModalLayer
    {
        [SerializeField]
        private Button closeButton = default;
        [SerializeField]
        private TextMeshProUGUI descriptionText = default;
        [SerializeField]
        private RectTransform itemParentTransform = default;

        private string modalId = default;
        private AppManager appMan = default;
        private List<SquareItem> squareItemsList = new List<SquareItem>();

        public void Setup()
        {
            appMan = AppManager.Instance;
            // Add to the modal layer list
            appMan.UIMan.AddToModalLayerList(this as IModalLayer);

            descriptionText.text = "This is a description";
            closeButton.onClick.AddListener(Shutdown);
            CreateBackpackContents();
        }

        public void Reset()
        {
            ClearSquareItemsList();
            CreateBackpackContents();
        }

        public void Shutdown()
        {
            closeButton.onClick.RemoveAllListeners();
            ClearSquareItemsList();

            // Remove from modal layer list
            appMan.UIMan.RemoveFromModalLayerList(this as IModalLayer);

            Destroy(gameObject);
        }

        public void CreateBackpackContents()
        {
            foreach (Item i in appMan.PlayerBackpack.ItemList)
            {
                SquareItem si = Instantiate(appMan.UIMan.SquareItemPrefab, itemParentTransform);
                si.Setup(item: i, locationCreated: SquareItem.LocationCreated.backpackModal);
                squareItemsList.Add(si);
            }
        }

        private void ClearSquareItemsList()
        {
            foreach (var i in squareItemsList)
            {
                i.Shutdown();
            }
            squareItemsList.Clear();
        }


        #region ModalLayer Functions

        public void ShowLayer()
        {
            Reset();
            this.gameObject.SetActive(true);
        }
        public void HideLayer()
        {
            this.gameObject.SetActive(false);
        }
        public string GetId()
        {
            return modalId;
        }

        public void AssignId(int layerIndex)
        {
            modalId = $"BackpackModal_{layerIndex}";
        }

        #endregion
    }
}