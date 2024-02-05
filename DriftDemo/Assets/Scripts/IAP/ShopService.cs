using UnityEngine;
using UnityEngine.Purchasing;

namespace Purchases
{
    [System.Serializable]
    public class ConsumableItem
    {
        public string Name;
        public string Id;
        public string Description;
        public float Price;
    }

    public class ShopService : IStoreListener
    {
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            throw new System.NotImplementedException();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            throw new System.NotImplementedException();
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}

