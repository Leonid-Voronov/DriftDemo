using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Purchases
{

    public class ShopService : IDetailedStoreListener
    {
        private ConsumableItem _consumableItem;

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            throw new System.NotImplementedException();
        }

        private void SetupBuilder()
        {
            _consumableItem = new ConsumableItem("Cash", "1", "Gives 100 cash", 1f);

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(_consumableItem.Id, ProductType.Consumable);
            UnityPurchasing.Initialize(this, builder);
        }
    }
}

