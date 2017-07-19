using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class CustomMergingController : UIViewController
    {
        public CustomMergingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PopulateGrid();

            Grid.SelectionChanged += Grid_SelectionChanged;
            ShowNameLabel.Text = "";
            ShowTimeLabel.Text = "";
            ShowTimeLabel.Lines = 0;
            ShowTimeLabel.LineBreakMode = UILineBreakMode.WordWrap;
        }
        private void PopulateGrid()
        {
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Monday", ""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Tuesday", "") , Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Wednesday", ""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Thursday",""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Friday", ""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Saturday", ""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });
            Grid.Columns.Add(new GridColumn { Header = Foundation.NSBundle.MainBundle.LocalizedString("Sunday",""), Width = GridLength.Star, MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Center, HorizontalAlignment = UIControlContentHorizontalAlignment.Center });

            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());
            Grid.Rows.Add(new GridRow());

            Grid.ColumnHeaders.Rows.Insert(0, new GridRow() { AllowMerging = true });
            Grid.ColumnHeaders[0, 0] = Foundation.NSBundle.MainBundle.LocalizedString("Weekday","");
            Grid.ColumnHeaders[0, 1] = Foundation.NSBundle.MainBundle.LocalizedString("Weekday","");
            Grid.ColumnHeaders[0, 2] = Foundation.NSBundle.MainBundle.LocalizedString("Weekday", "");
            Grid.ColumnHeaders[0, 3] = Foundation.NSBundle.MainBundle.LocalizedString("Weekday", "");
            Grid.ColumnHeaders[0, 4] = Foundation.NSBundle.MainBundle.LocalizedString("Weekday", "");
            Grid.ColumnHeaders[0, 5] = Foundation.NSBundle.MainBundle.LocalizedString("Weekend", "");
            Grid.ColumnHeaders[0, 6] = Foundation.NSBundle.MainBundle.LocalizedString("Weekend", "");

            Grid.RowHeaders.Columns[0].Width = GridLength.Auto;
            Grid.RowHeaders[0, 0] = "12:00";
            Grid.RowHeaders[1, 0] = "13:00";
            Grid.RowHeaders[2, 0] = "14:00";
            Grid.RowHeaders[3, 0] = "15:00";
            Grid.RowHeaders[4, 0] = "16:00";
            Grid.RowHeaders[5, 0] = "17:00";
            Grid.RowHeaders[6, 0] = "18:00";

            Grid[0, 0] = "Walker";
            Grid[0, 1] = "Morning Show";
            Grid[0, 2] = "Morning Show";
            Grid[0, 3] = "Sports";
            Grid[0, 4] = "Weather";
            Grid[0, 5] = "N/A";
            Grid[0, 6] = "N/A";
            Grid[1, 5] = "N/A";
            Grid[1, 6] = "N/A";
            Grid[2, 5] = "N/A";
            Grid[2, 6] = "N/A";
            Grid[3, 5] = "N/A";
            Grid[3, 6] = "N/A";
            Grid[4, 5] = "N/A";
            Grid[4, 6] = "N/A";
            Grid[1, 0] = "Today Show";
            Grid[1, 1] = "Today Show";
            Grid[2, 0] = "Today Show";
            Grid[2, 1] = "Today Show";
            Grid[1, 2] = "Sesame Street";
            Grid[1, 3] = "Football";
            Grid[2, 3] = "Football";
            Grid[1, 4] = "Market Watch";
            Grid[2, 2] = "Kids Zone";
            Grid[2, 4] = "Soap Opera";
            Grid[3, 0] = "News";
            Grid[3, 1] = "News";
            Grid[3, 2] = "News";
            Grid[3, 3] = "News";
            Grid[3, 4] = "News";
            Grid[4, 0] = "News";
            Grid[4, 1] = "News";
            Grid[4, 2] = "News";
            Grid[4, 3] = "News";
            Grid[4, 4] = "News";
            Grid[5, 0] = "Wheel of Fortune";
            Grid[5, 1] = "Wheel of Fortune";
            Grid[5, 2] = "Wheel of Fortune";
            Grid[5, 3] = "Jeopardy";
            Grid[5, 4] = "Jeopardy";
            Grid[5, 5] = "Movie";
            Grid[6, 5] = "Movie";
            Grid[5, 6] = "Golf";
            Grid[6, 6] = "Golf";
            Grid[6, 0] = "Night Show";
            Grid[6, 1] = "Night Show";
            Grid[6, 2] = "Sports";
            Grid[6, 3] = "Big Brother";
            Grid[6, 4] = "Big Brother";
        }

        private void Grid_SelectionChanged(object sender, GridCellRangeEventArgs e)
        {

            string selectedText = Grid[e.CellRange.Row, e.CellRange.Column].ToString();
            ShowNameLabel.Text = selectedText;
            ShowTimeLabel.Text = "";
            for (int c = 0; c < Grid.Columns.Count; c++)
            {
                string dayName = Grid.GetCellValue(GridCellType.ColumnHeader, new GridCellRange(1, c)).ToString();
                string startTime = "";
                for (int r = 0; r < Grid.Rows.Count; r++)
                {
                    string cellValue = Grid[r, c].ToString();

                    if (cellValue.Equals(selectedText))
                    {
                        if (startTime == "")
                        {
                            startTime = Grid.GetCellValue(GridCellType.RowHeader, Grid.Rows[r], Grid.Columns[0]).ToString();
                            ShowTimeLabel.Text = ShowTimeLabel.Text + dayName + " " + startTime + "-";
                        }
                    }
                    else if (startTime != "" && ShowTimeLabel.Text.EndsWith("-"))
                    {
                        string endTime = Grid.GetCellValue(GridCellType.RowHeader, Grid.Rows[r], Grid.Columns[0]).ToString();
                        ShowTimeLabel.Text = ShowTimeLabel.Text + endTime + "\n";
                    }

                    // handle last row exception
                    if (r == Grid.Rows.Count - 1 && startTime != "" && ShowTimeLabel.Text.EndsWith("-"))
                    {
                        ShowTimeLabel.Text = ShowTimeLabel.Text + "19:00\n";
                    }
                }
            }
        }
    }
}