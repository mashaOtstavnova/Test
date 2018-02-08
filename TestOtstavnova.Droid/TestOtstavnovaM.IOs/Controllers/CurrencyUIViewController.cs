using Foundation;
using System;
using CoreGraphics;
using Shared.DataService;
using Shared.Helpers;
using TestOtstavnovaM.IOs.TableView;
using UIKit;
using System.Timers;

namespace TestOtstavnovaM.IOs
{
    public partial class CurrencyUIViewController : UIViewController
    {
        private const int IntervalMilisecond = 15000;

        private UITableView _tableView;
        private CurrencyTableView _tableViewSource;
        private Timer _timer;

        public CurrencyUIViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _tableView =
                new UITableView(new CGRect(CommonMargin.LeftMarginNeutralViews, CommonMargin.TopMarginNeutralViews,
                    View.Frame.Width, View.Frame.Height))
                {
                    BackgroundColor = View.BackgroundColor = UIColor.White,
                    SeparatorStyle = UITableViewCellSeparatorStyle.None,
                };
            var data = DataClient.GetCurrency();
            if (data == null) return;
            _tableViewSource = new CurrencyTableView(data.Stock);
            _tableView.Source = _tableViewSource;
            View.AddSubviews(_tableView);

            Reload.Clicked += (sender, args) => ReloadData();

            _timer = new Timer(IntervalMilisecond);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            var data = DataClient.GetCurrency();
            _tableViewSource.ListCurrencies = data.Stock;
            _tableView.ReloadData();
            if (data?.Stock.Count != 0)
                _tableView.ReloadRows(new NSIndexPath[] {NSIndexPath.FromRowSection(0, 0)},
                    UITableViewRowAnimation.Fade);
        }
    }
}