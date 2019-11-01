using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Tortuga.Sails
{
    /// <summary>
    /// Helper functions for the visual tree
    /// </summary>
    public static partial class VisualTreeExtensions
    {
        /// <summary>
        /// Returns true is the control or one of its children has the focus.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        /// <remarks>
        /// This starts at the focused object and walks the visual tree upwards
        /// </remarks>
        public static bool ContainsFocus(this DependencyObject control)
        {
            var current = FocusManager.GetFocusedElement(FocusManager.GetFocusScope(control)) as DependencyObject;

            while (current != null)
            {
                if (current == control) return true;
                current = VisualTreeHelper.GetParent(current);
            }
            return false;
        }

        /// <summary>
        /// This gives the focus to the indicated control. If it is not focusable, walk the visual tree until a control that can accept it is found.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// True if a control accepted the focus.
        /// </returns>
        /// <remarks>
        /// This uses a depth-first search.
        /// </remarks>
        public static bool FocusRecursive(this DependencyObject control)
        {
            var focusable = control as UIElement;
            //Try to give the focus to the control. Note that this will fail if the control is hidden.
            if (focusable != null && focusable.Focusable && focusable.Focus())
                return true;

            var childCount = VisualTreeHelper.GetChildrenCount(control);
            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(control, i);

                //Check to see if any of the child objects can accept the focus
                if (FocusRecursive(child))
                    return true;
            }
            return false; //didn't find a focusable control
        }

        /// <summary>
        /// Gets the first visual child of the given type for the indicated control.
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        public static T GetVisualChild<T>(this DependencyObject control) where T : DependencyObject
        {
            var childCount = VisualTreeHelper.GetChildrenCount(control);
            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(control, i);

                if (child is T)
                    return (T)child;

                var result = GetVisualChild<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the first visual child of the given type for the indicated control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="targetType">Type to search for.</param>
        /// <returns></returns>
        public static DependencyObject GetVisualChild(this DependencyObject control, Type targetType)
        {
            var childCount = VisualTreeHelper.GetChildrenCount(control);
            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(control, i);

                if (child.GetType() == targetType)
                    return child;

                var result = GetVisualChild(child, targetType);

                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the visual parent of a given type for the indicated control.
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        public static T GetVisualParent<T>(this DependencyObject control) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(control);

            if (parent == null)
                return null;
            else if (parent is T)
                return (T)parent;
            else
                return GetVisualParent<T>(parent);
        }

        /// <summary>
        /// Gets the visual parent of a given type for the indicated control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="targetType">Type to search for.</param>
        /// <returns></returns>
        public static DependencyObject GetVisualParent(this DependencyObject control, Type targetType)
        {
            var parent = VisualTreeHelper.GetParent(control);

            if (parent == null)
                return null;
            else if (parent.GetType() == targetType)
                return parent;
            else
                return GetVisualParent(parent, targetType);
        }
    }
}
