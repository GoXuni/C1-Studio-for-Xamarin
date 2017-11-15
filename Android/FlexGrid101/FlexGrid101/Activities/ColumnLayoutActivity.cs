using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using C1.Android.Grid;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/ColumnLayoutTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class ColumnLayoutActivity : AppCompatActivity
    {
        private string FILENAME = "ColumnLayout.json";
        private int EditFormRequest;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.ColumnLayoutTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            InitializeColumnLayout();
        }
        public FlexGrid Grid { get; set; }

        async void InitializeColumnLayout()
        {
            var data = await FileSystem.ReadFileFromDisk(FILENAME);

            var items = Customer.GetCustomerList(100);
            Grid.ItemsSource = items;

            if (!string.IsNullOrWhiteSpace(data))
                DeserializeLayout(Grid, data);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var saveMenuItem = menu.Add(0, 0, 0, Resource.String.ColumnLayoutSave);
            var editMenuItem = menu.Add(0, 1, 0, Resource.String.ColumnLayoutEdit);
            saveMenuItem.SetShowAsAction(ShowAsAction.Always);
            editMenuItem.SetShowAsAction(ShowAsAction.Always);
            saveMenuItem.SetIcon(Resource.Drawable.ic_action_save);
            editMenuItem.SetIcon(Resource.Drawable.ic_edit);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                SaveColumnLayout();
            }
            else if (item.ItemId == 1)
            {
                EditColumnLayout();
            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        private async void EditColumnLayout()
        {
            EditFormRequest = new Random().Next(65536);
            var layoutText = await SerializeLayout(Grid);
            var intent = new Intent(this, typeof(ColumnLayoutFormActivity));
            intent.PutExtra("columnLayout", layoutText);
            StartActivityForResult(intent, EditFormRequest);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == EditFormRequest)
            {
                if (resultCode == Result.Ok)
                {
                    var layoutText = data.GetStringExtra("columnLayout");
                    DeserializeLayout(Grid, layoutText);
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        async void SaveColumnLayout()
        {
            var serializedColumns = await SerializeLayout(Grid);
            await FileSystem.SaveFileToDisk(FILENAME, serializedColumns);
        }

        public static async Task<string> SerializeLayout(ColumnInfo[] columns)
        {
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, columns);
            await stream.FlushAsync();
            stream.Seek(0, SeekOrigin.Begin);
            var serializedColumns = await new StreamReader(stream).ReadToEndAsync();
            return serializedColumns;
        }

        public static ColumnInfo[] DeserializeLayout(string layout)
        {
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(layout));
            return serializer.ReadObject(stream) as ColumnInfo[];
        }

        private async Task<string> SerializeLayout(FlexGrid grid)
        {
            var columns = new List<ColumnInfo>();
            foreach (var col in grid.Columns)
            {
                var colInfo = new ColumnInfo { Name = col.Binding, IsVisible = col.IsVisible };
                columns.Add(colInfo);
            }
            return await SerializeLayout(columns.ToArray());
        }

        private void DeserializeLayout(FlexGrid grid, string layout)
        {
            var columns = DeserializeLayout(layout);
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
    }

    public class FileSystem
    {
        public static async Task SaveFileToDisk(string fileName, string data)
        {
            var dir = Application.Context.FilesDir;
            var file = new Java.IO.File(dir, fileName);
            if (!file.Exists())
                file.CreateNewFile();
            using (var stream = System.IO.File.Open(file.AbsolutePath, System.IO.FileMode.Truncate, System.IO.FileAccess.ReadWrite))
            {
                var buffer = UTF8Encoding.UTF8.GetBytes(data);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                await stream.FlushAsync();
            }
        }

        public static async Task<string> ReadFileFromDisk(string fileName)
        {
            var dir = Application.Context.FilesDir;
            var file = new Java.IO.File(dir, fileName);
            if (file.Exists())
            {
                using (var stream = System.IO.File.Open(file.AbsolutePath, System.IO.FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    return await reader.ReadToEndAsync();
                }
            }
            return null;
        }
    }
}