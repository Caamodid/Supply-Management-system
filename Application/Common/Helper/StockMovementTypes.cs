using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helper
{
    public static class StockMovementTypes
    {
        public const string Adjustment = "ADJUSTMENT";
        public const string Receive = "RECEIVE";
        public const string TransferOut = "TRANSFER_OUT";
        public const string TransferIn = "TRANSFER_IN";
        public const string Conversion = "CONVERSION";
        public const string Sale = "Sale";
        public const string CancelSale = "Cancel_Sale";
    }

}
