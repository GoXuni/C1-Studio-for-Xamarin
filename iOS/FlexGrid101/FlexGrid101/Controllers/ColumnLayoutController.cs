using Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class ColumnLayoutController : UIViewController
    {
        private string FILENAME = "ColumnLayout.json";

        public ColumnLayoutController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeColumnLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }

        async void InitializeColumnLayout()
        {
            var data = await FileSystem.ReadFileFromDisk(FILENAME);

            var items = Customer.GetCustomerList(100);
            Grid.AutoGeneratingColumn += (s, e) => { e.Column.MinWidth = 110; e.Column.Width = GridLength.Star; };
            Grid.ItemsSource = items;

            if (!string.IsNullOrWhiteSpace(data))
                DeserializeLayout(Grid, data);
        }

        async partial void SaveButton_Activated(UIBarButtonItem sender)
        {
            var serializedColumns = await SerializeLayout(Grid);
            await FileSystem.SaveFileToDisk(FILENAME, serializedColumns);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var columns = new ObservableCollection<ColumnInfo>();
            foreach (var col in Grid.Columns)
            {
                var colInfo = new ColumnInfo { Name = col.ActualHeader, IsVisible = col.IsVisible, Column = col };
                columns.Add(colInfo);
            }

            var formController = (segue.DestinationViewController as UINavigationController).ChildViewControllers.First() as ColumnLayoutFormController;
            formController.Columns = columns;
        }

        [Action("CloseColumnLayoutForm:")]
        public void CloseColumnLayoutForm(UIStoryboardSegue segue)
        {
            var formController = segue.SourceViewController as ColumnLayoutFormController;
            if (formController.Saved)
            {
                for (int i = 0; i < formController.Columns.Count; i++)
                {
                    var cvm = formController.Columns[i];
                    var currentIndex = Grid.Columns.IndexOf(cvm.Column);
                    if (currentIndex != i)
                    {
                        Grid.Columns.Move(currentIndex, i);
                    }
                    if (cvm.IsVisible != cvm.Column.IsVisible)
                    {
                        cvm.Column.IsVisible = cvm.IsVisible;
                    }
                }
            }
        }

        private async Task<string> SerializeLayout(FlexGrid grid)
        {
            var columns = new List<ColumnInfo>();
            foreach (var col in grid.Columns)
            {
                var colInfo = new ColumnInfo { Name = col.Binding, IsVisible = col.IsVisible, Column = col };
                columns.Add(colInfo);
            }
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, columns.ToArray());
            await stream.FlushAsync();
            stream.Seek(0, SeekOrigin.Begin);
            var serializedColumns = await new StreamReader(stream).ReadToEndAsync();
            return serializedColumns;
        }

        private void DeserializeLayout(FlexGrid grid, string layout)
        {
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(layout));
            var columns = serializer.ReadObject(stream) as ColumnInfo[];
            for (int i = 0; i < columns.Length; i++)
            {
                var colInfo = columns[i];
                var column = grid.Columns[colInfo.Name];
                var colIndex = grid.Columns.IndexOf(column);
                column.IsVisible = colInfo.IsVisible;
                if (colIndex != i)
                {
                    grid.Columns.Move(colIndex, i);
                }
            }
        }
    }

    [DataContract]
    public class ColumnInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "isVisible")]
        public bool IsVisible { get; set; }
        public GridColumn Column { get; internal set; }
    }

    public class FileSystem
    {
        public static async Task SaveFileToDisk(string fileName, string data)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var file = Path.GetFullPath(Path.Combine(dir, fileName));

            using (var stream = System.IO.File.Open(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var buffer = UTF8Encoding.UTF8.GetBytes(data);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                await stream.FlushAsync();
            }
        }

        public static async Task<string> ReadFileFromDisk(string fileName)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var file = Path.GetFullPath(Path.Combine(dir, fileName));

            if (System.IO.File.Exists(file))
            {
                using (var stream = System.IO.File.Open(file, System.IO.FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    return await reader.ReadToEndAsync();
                }
            }

            return null;
        }
    }
}