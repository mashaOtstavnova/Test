using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using CoreGraphics;
using Foundation;
using Shared.Models.JSON;
using UIKit;

namespace TestOtstavnovaM.IOs.TableView
{
    public class CurrencyTableView : UITableViewSource
    {
        public List<Stock> ListCurrencies { get; set; }
        private readonly Dictionary<int, float> _heights = new Dictionary<int, float>();


        public CurrencyTableView(List<Stock> listCurrencies)// controller)
        {
            //_controller = controller;
            ListCurrencies = listCurrencies;
            InitList();
        }

        private void InitList()
        {
            ListCurrencies = ListCurrencies.OrderBy(t=>t.Name).ToList();
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return _heights.ContainsKey(indexPath.Row) ? _heights[indexPath.Row] : 0;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("CurrencyTableCell") as CurrencyTableCell 
                ?? new CurrencyTableCell(new NSString("CurrencyTableCell"));
            cell.ContentView.Subviews?.ToList().ForEach(w => w.RemoveFromSuperview());
            var itemStock = ListCurrencies[indexPath.Row];
            cell.UpdateCell(itemStock);

            if (_heights.ContainsKey(indexPath.Row))
                _heights.Remove(indexPath.Row);

            _heights.Add(indexPath.Row, cell.Heigth);
            //var tap = new UITapGestureRecognizer(() => OpenNextController(record));

            //cell.ContentView.AddGestureRecognizer(tap);


            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ListCurrencies.Count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }
    }
}