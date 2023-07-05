using ConnectIt;
using UnityEngine;

public class PurchasingManager : Singleton<PurchasingManager>
{
   public void OnPressDown(int i)
   {
      switch (i)
      {
         case 1:
            IAPManager.OnPurchaseSuccess = () => 
            GameDataManager.Instance.playerData.AddHelp(1);
             IAPManager.Instance.BuyProductID(Key.PACK1);
            break;
         case 2:
            IAPManager.OnPurchaseSuccess = () => 
            GameDataManager.Instance.playerData.AddHelp(15);
            IAPManager.Instance.BuyProductID(Key.PACK2);
            break;
         case 3:
            IAPManager.OnPurchaseSuccess = () => 
            GameDataManager.Instance.playerData.AddHelp(30);
            IAPManager.Instance.BuyProductID(Key.PACK3);
            break;
         case 4:
            IAPManager.OnPurchaseSuccess = () => 
            GameDataManager.Instance.playerData.AddHelp(75);
            IAPManager.Instance.BuyProductID(Key.PACK4);
            break;
      }
   }

   public void Sub(int i)
   {
      GameDataManager.Instance.playerData.SubHelp(i);
   }
}
