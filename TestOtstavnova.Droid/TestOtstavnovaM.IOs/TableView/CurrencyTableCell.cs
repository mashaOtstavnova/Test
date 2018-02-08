using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Shared.Helpers;
using Shared.Models.JSON;
using TestOtstavnovaM.IOs.CustomElements;
using TestOtstavnovaM.IOs.Extentions;
using UIKit;

namespace TestOtstavnovaM.IOs.TableView
{
    public class CurrencyTableCell : UITableViewCell
    {
        private StockView _cellView;
        public CurrencyTableCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        public float Heigth { get; set; }

        private CGRect _bounds => UIScreen.MainScreen.Bounds;

        public void UpdateCell(Stock stok)
        {
            if (stok == null) return;

            _cellView = new StockView(_bounds.Width, stok);
            Heigth = (float)_cellView.Frame.Height;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            ContentView.Subviews?.ToList().ForEach(w => w.RemoveFromSuperview());

            if (_cellView != null)
                ContentView.AddSubviews(_cellView);
        }

    }
    
}