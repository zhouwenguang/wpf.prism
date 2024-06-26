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
    public static class DataGridSelectionChangedBehavior
    {
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached(
                "SelectionChangedCommand",
                typeof(ICommand),
                typeof(DataGridSelectionChangedBehavior),
                new FrameworkPropertyMetadata(null, OnSelectionChangedCommandChanged));

        public static ICommand GetSelectionChangedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectionChangedCommandProperty);
        }

        public static void SetSelectionChangedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectionChangedCommandProperty, value);
        }

        private static void OnSelectionChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid grid)
            {
                grid.SelectionChanged += (sender, args) =>
                {
                    ICommand command = GetSelectionChangedCommand(grid);
                    if (command != null && command.CanExecute(grid.SelectedItem))
                    {
                        command.Execute(grid.SelectedItem);
                    }
                };
            }
        }
    }
}
