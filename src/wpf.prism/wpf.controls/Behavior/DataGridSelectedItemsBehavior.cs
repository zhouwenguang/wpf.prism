using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace wpf.controls.Behavior
{
    public static class DataGridSelectedItemsBehavior
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(IList),
                typeof(DataGridSelectedItemsBehavior),
                new PropertyMetadata(null, OnSelectedItemsChanged));

        public static IList GetSelectedItems(DependencyObject obj)
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DependencyObject obj, IList value)
        {
            obj.SetValue(SelectedItemsProperty, value);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid dataGrid)
            {
                //dataGrid.Loaded += (s, e) => SelectItems(dataGrid);
                dataGrid.SelectionChanged -= DataGrid_SelectionChanged;
                if (e.NewValue != null)
                {
                    dataGrid.SelectionChanged += DataGrid_SelectionChanged;
                }
            }
        }

        private static void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null) return;

            IList selectedItems = GetSelectedItems(dataGrid);
            if (selectedItems == null) return;

            selectedItems.Clear();
            foreach (var item in dataGrid.SelectedItems)
            {
                if(item is object)
                    selectedItems.Add(item);
            }
        }

        private static void SelectItems(DataGrid dataGrid)
        {
            IList selectedItems = GetSelectedItems(dataGrid);
            if (selectedItems == null) return;

            dataGrid.SelectedItems.Clear();
            foreach (var item in selectedItems)
            {
                dataGrid.SelectedItems.Add(item);
            }
        }
    }
}
