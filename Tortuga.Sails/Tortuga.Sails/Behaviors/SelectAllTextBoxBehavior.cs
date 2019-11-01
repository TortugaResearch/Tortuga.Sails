using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using i = Microsoft.Xaml.Behaviors;

namespace Tortuga.Sails
{
    /// <summary>
    /// This behavior/attached property causes all of the text in the textbox to be automatically selected when the user tabs into the control. Optionally, it also selects the text when the user clicks on it with the mouse.
    /// </summary>
    /// <remarks>
    ///
    /// xmlns:s="clr-namespace:Tortuga.Sails;assembly=Tortuga.Sails"
    /// xmlns:i="clr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors"
    ///
    /// Attached Property Syntax:
    ///
    /// s:SelectAllTextBoxBehavior.IsEnabled="True"
    /// s:SelectAllTextBoxBehavior.SelectOnMouseClick="True"
    ///
    /// Behaviors syntax
    ///
    /// &lt;i:Interaction.Behaviors&gt;
    ///     &lt;s:SelectAllTextBoxBehavior OnMouseClick = "True" /&gt;
    /// &lt;/ i:Interaction.Behaviors&gt;
    ///
    /// </remarks>
    public class SelectAllTextBoxBehavior : i.Behavior<TextBox>
    {
        bool m_AlreadyFocused;

        /// <summary>
        /// Gets or sets a value indicating whether select all occurs on mouse click.
        /// </summary>
        public bool OnMouseClick { get; set; }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            if (!DesignerProperties.GetIsInDesignMode(AssociatedObject))
            {
                AssociatedObject.GotFocus += Target_GotFocus;
                AssociatedObject.PreviewMouseUp += Target_MouseUp; //Need PreviewMouseUp or it can be swallowed by a child control
                AssociatedObject.LostFocus += Target_LostFocus;
            }
            base.OnAttached();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            if (!DesignerProperties.GetIsInDesignMode(AssociatedObject))
            {
                AssociatedObject.GotFocus -= Target_GotFocus;
                AssociatedObject.PreviewMouseUp -= Target_MouseUp;
                AssociatedObject.LostFocus -= Target_LostFocus;
            }
            base.OnDetaching();
        }

        private void Target_GotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("LeftButton: " + Mouse.LeftButton);
            Debug.WriteLine("MiddleButton: " + Mouse.MiddleButton);
            Debug.WriteLine("RightButton: " + Mouse.RightButton);
            Debug.WriteLine("XButton1: " + Mouse.XButton1);
            Debug.WriteLine("XButton2: " + Mouse.XButton2);
            if (Mouse.LeftButton == MouseButtonState.Released & Mouse.MiddleButton == MouseButtonState.Released & Mouse.RightButton == MouseButtonState.Released & Mouse.XButton1 == MouseButtonState.Released & Mouse.XButton2 == MouseButtonState.Released)
            {
                AssociatedObject.SelectAll();
                m_AlreadyFocused = true;
                Debug.WriteLine("GotFocus --> Select All");
            }
            else
            {
                Debug.WriteLine("GotFocus " + m_AlreadyFocused);
            }
        }

        void Target_LostFocus(object sender, RoutedEventArgs e)
        {
            m_AlreadyFocused = false;
            Debug.WriteLine("LostFocus " + m_AlreadyFocused);
        }

        void Target_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!m_AlreadyFocused & AssociatedObject.SelectionLength == 0 && OnMouseClick)
            {
                m_AlreadyFocused = true;
                AssociatedObject.SelectAll();
                Debug.WriteLine("MouseUp --> Select All");
            }
            else
            {
                Debug.WriteLine("MouseUp " + m_AlreadyFocused + " OnMouse: " + OnMouseClick);
            }
        }

        #region "Boilerplate for XAML Attached Properties"

#pragma warning disable CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Backing field for the IsEnabled property
        /// </summary>
        public static DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(SelectAllTextBoxBehavior), new FrameworkPropertyMetadata(false, OnIsEnabledChanged));

#pragma warning restore CA2211 // Non-constant fields should not be visible

#pragma warning disable CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Backing field for the SelectOnMouseClick property
        /// </summary>
        public static DependencyProperty SelectOnMouseClickProperty = DependencyProperty.RegisterAttached("SelectOnMouseClick", typeof(bool), typeof(SelectAllTextBoxBehavior), new FrameworkPropertyMetadata(false, OnSelectOnMouseClickChanged));

#pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Getter for the IsEnabled property.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <exception cref="System.ArgumentNullException">uie</exception>
        public static bool GetIsEnabled(DependencyObject uie)
        {
            if (uie == null)
                throw new ArgumentNullException(nameof(uie), $"{nameof(uie)} is null.");

            return (bool)(uie.GetValue(IsEnabledProperty));
        }

        /// <summary>
        /// Getter for the SelectOnMouseClick property.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <exception cref="System.ArgumentNullException">uie</exception>
        public static bool GetSelectOnMouseClick(DependencyObject uie)
        {
            if (uie == null)
                throw new ArgumentNullException(nameof(uie), $"{nameof(uie)} is null.");

            return (bool)(uie.GetValue(SelectOnMouseClickProperty));
        }

        /// <summary>
        /// Setter for the IsEnabled property.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <param name="value">if set to <c>true</c> to enable this behavior.</param>
        /// <exception cref="System.ArgumentNullException">uie</exception>
        public static void SetIsEnabled(DependencyObject uie, bool value)
        {
            if (uie == null)
                throw new ArgumentNullException(nameof(uie), $"{nameof(uie)} is null.");

            uie.SetValue(IsEnabledProperty, value);
        }

        /// <summary>
        /// Setter for the SelectOnMouseClick property.
        /// </summary>
        /// <param name="uie">The uie.</param>
        /// <param name="value">if set to <c>true</c> to enable select all on-mouse clicks.</param>
        /// <exception cref="System.ArgumentNullException">uie</exception>
        public static void SetSelectOnMouseClick(DependencyObject uie, bool value)
        {
            if (uie == null)
                throw new ArgumentNullException(nameof(uie), $"{nameof(uie)} is null.");

            uie.SetValue(SelectOnMouseClickProperty, value);
        }

        static void OnIsEnabledChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            var uie = dpo as UIElement;
            if (uie == null)
                return;

            var behaviors = i.Interaction.GetBehaviors(uie);
            var existingBehavior = behaviors.FirstOrDefault(b => b.GetType() == typeof(SelectAllTextBoxBehavior)) as SelectAllTextBoxBehavior;

            if ((bool)e.NewValue == false && existingBehavior != null)
            {
                behaviors.Remove(existingBehavior);
            }
            else if ((bool)e.NewValue == true && existingBehavior == null)
            {
                behaviors.Add(new SelectAllTextBoxBehavior() { OnMouseClick = GetSelectOnMouseClick(dpo) });
            }
        }

        static void OnSelectOnMouseClickChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            var uie = dpo as UIElement;
            if (uie == null)
                return;

            var behaviors = i.Interaction.GetBehaviors(uie);
            var existingBehavior = behaviors.FirstOrDefault(b => b.GetType() == typeof(SelectAllTextBoxBehavior)) as SelectAllTextBoxBehavior;

            if (existingBehavior != null)
            {
                existingBehavior.OnMouseClick = (bool)e.NewValue;
            }
            else if ((bool)e.NewValue == true && existingBehavior == null)
            {
                SetIsEnabled(dpo, true);
                behaviors.Add(new SelectAllTextBoxBehavior() { OnMouseClick = true });
            }
        }

        #endregion "Boilerplate for XAML Attached Properties"
    }
}
