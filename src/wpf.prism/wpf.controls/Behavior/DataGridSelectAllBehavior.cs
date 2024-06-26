using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace wpf.controls.Behavior
{
    public static class DataGridSelectAllBehavior
    {
        public static readonly DependencyProperty SelectAllCommandProperty =
            DependencyProperty.RegisterAttached(
                "SelectAllCommand",
                typeof(ICommand),
                typeof(DataGridSelectAllBehavior),
                new PropertyMetadata(null, OnSelectAllCommandChanged));

        public static ICommand GetSelectAllCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectAllCommandProperty);
        }

        public static void SetSelectAllCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectAllCommandProperty, value);
        }

        private static void OnSelectAllCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid dataGrid)
            {
                if (e.NewValue is ICommand)
                {
                    dataGrid.LoadingRow += DataGrid_LoadingRow;
                }
                else
                {
                    dataGrid.LoadingRow -= DataGrid_LoadingRow;
                }
            }
        }

        private static void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var command = GetSelectAllCommand(dataGrid);
            if (command != null && command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}
