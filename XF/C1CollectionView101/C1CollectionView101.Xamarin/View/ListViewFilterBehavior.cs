using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.CollectionView;

namespace C1CollectionView101
{
    public class ListViewFilterBehavior : Behavior<ListView>
    {
        #region ** fields

        private ListView Grid;

        private ICollectionView<object> CollectionView
        {
            get
            {
                return Grid.ItemsSource as ICollectionView<object>;
            }
        }

        #endregion

        #region ** initialization

        protected override void OnAttachedTo(ListView grid)
        {
            base.OnAttachedTo(grid);
            Grid = grid;
            Grid.PropertyChanged += OnPropertyChanged;
            InitializeListView();
        }

        protected override void OnDetachingFrom(ListView grid)
        {
            Grid.PropertyChanged -= OnPropertyChanged;
            Grid = null;
            base.OnDetachingFrom(grid);
        }

        private void InitializeListView()
        {
        }

        private void FinalizeListView()
        {
        }

        #endregion

        #region ** object model

        public static readonly BindableProperty FilterEntryProperty = BindableProperty.Create<ListViewFilterBehavior, Entry>(p => p.FilterEntry, null, propertyChanged: (s, o, n) => (s as ListViewFilterBehavior).OnFilterEntryChanged(o, n));
        public static readonly BindableProperty ModeProperty = BindableProperty.Create<ListViewFilterBehavior, FullTextFilterMode>(p => p.Mode, FullTextFilterMode.WhenCompleted);
        public static readonly BindableProperty MatchNumbersProperty = BindableProperty.Create<ListViewFilterBehavior, bool>(p => p.MatchNumbers, false);
        public static readonly BindableProperty TreatSpacesAsAndOperatorProperty = BindableProperty.Create<ListViewFilterBehavior, bool>(p => p.TreatSpacesAsAndOperator, false);

        /// <summary>
        /// Gets or sets the Entry field used to perform the query.
        /// </summary>
        public Entry FilterEntry
        {
            get { return (Entry)GetValue(FilterEntryProperty); }
            set { SetValue(FilterEntryProperty, value); }
        }

        public FullTextFilterMode Mode
        {
            get { return (FullTextFilterMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether number columns should be taken into account.
        /// </summary>
        public bool MatchNumbers
        {
            get { return (bool)GetValue(MatchNumbersProperty); }
            set { SetValue(MatchNumbersProperty, value); }
        }

        /// <summary>
        /// Specifies whether the spaces act as "AND" operator or the query should be matched as it is, including spaces.
        /// </summary>
        public bool TreatSpacesAsAndOperator
        {
            get { return (bool)GetValue(TreatSpacesAsAndOperatorProperty); }
            set { SetValue(TreatSpacesAsAndOperatorProperty, value); }
        }

        #endregion

        #region ** implementation

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ItemsSource")
            {
                FinalizeListView();
                InitializeListView();
            }
        }

        private void OnFilterEntryChanged(Entry o, Entry n)
        {
            if (o != null)
            {
                o.TextChanged -= OnFilterEntryTextChanged;
                o.Completed -= OnFilterEntryCompleted;
            }
            if (n != null)
            {
                n.TextChanged += OnFilterEntryTextChanged;
                n.Completed += OnFilterEntryCompleted;
            }
        }

        private async void OnFilterEntryCompleted(object sender, EventArgs e)
        {
            try
            {
                if (Mode == FullTextFilterMode.WhenCompleted && Grid != null && CollectionView is ISupportFiltering)
                {
                    await FilterBy(CollectionView, FilterEntry.Text);
                }
            }
            catch { }
        }

        private async void OnFilterEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Mode == FullTextFilterMode.WhileTyping && Grid != null && CollectionView is ISupportFiltering)
                {
                    await FilterBy(CollectionView, e.NewTextValue);
                }
            }
            catch { }
        }

        private async Task FilterBy(ICollectionView<object> collectionView, string query)
        {
            await (collectionView as ISupportFiltering).FilterAsync(collectionView.CreateFilterFromString(query, TreatSpacesAsAndOperator, MatchNumbers));
        }

        #endregion
    }

    public enum FullTextFilterMode
    {
        WhileTyping,
        WhenCompleted,
    }
}
