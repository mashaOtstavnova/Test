using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Shared.Helpers;
using Shared.Models.JSON;
using TestOtstavnovaM.IOs.Extentions;
using UIKit;

namespace TestOtstavnovaM.IOs.CustomElements
{
    public class StockView : UIView
    {
        public static float Height = 50;
        public StockView(nfloat width, Stock stok) : base(new CGRect(CommonMargin.LeftMarginNeutralViews, CommonMargin.TopMarginNeutralViews, width, Height))
        {
            var leftRightMarginTitle = CommonMargin.LeftMarginViews;
            var widthLabel = ((width - leftRightMarginTitle * 4) / 4) * 2;//берем 2/4 экрана (- 4 отступа)
            var widthValue = ((width - leftRightMarginTitle * 4) / 4); //берем 1/4 экрана (- 4 отступа)
            var label = new UILabel(new CGRect(leftRightMarginTitle,
                CommonMargin.TopMarginNeutralViews, widthLabel, Height))
            {
                Text = stok.Name,
                TextColor = UIColor.Black
            };
            var volume = new UILabel(new CGRect(leftRightMarginTitle + label.GetEndViewWidth(),
                CommonMargin.TopMarginNeutralViews, widthValue, Height))
            {
                Text = Math.Round((decimal)stok.Volume, 0).ToString(),
                TextColor = UIColor.Black
            };
            var amount = new UILabel(new CGRect(leftRightMarginTitle + volume.GetEndViewWidth(),
                CommonMargin.TopMarginNeutralViews, widthValue, Height))
            {
                Text = Math.Round((decimal)stok.Price.Amount, 2).ToString(),
                TextColor = UIColor.Black
            };
            AddSubviews(label, volume, amount);

        }
    }
}