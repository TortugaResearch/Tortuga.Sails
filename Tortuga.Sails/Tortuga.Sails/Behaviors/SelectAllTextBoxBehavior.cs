using System;
using System.ComponentModel;
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
    ///<para>
    /// xmlns:s="clr-namespace:Tortuga.Sails;assembly=Tortuga.Sails"
    /// xmlns:b="clr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors"
    ///</para>
    ///<para>
    /// Attached Property Syntax:
    ///</para>
    ///<para>   
    /// s:SelectAllTextBoxBehavior.IsEnabled="True"
    /// s:SelectAllTextBoxBehavior.SelectOnMouseClick="True"
    ///</para>
    ///<para>
    /// Behaviors syntax
    ///</para>
    ///<para>    
    /// &lt;b:Interaction.Behaviors&gt;
    ///     &lt;s:SelectAllTextBoxBehavior OnMouseClick = "True" /&gt;
    /// &lt;/ b:Interaction.Behaviors&gt;
    ///</para>
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
            if (Mouse.LeftButton == MouseButtonState.Released && Mouse.MiddleButton == MouseButtonState.Released && Mouse.RightButton == MouseButtonState.Released && Mouse.XButton1 == MouseButtonState.Released && Mouse.XButton2 == MouseButtonState.Released)
            {
                AssociatedObject.SelectAll();
                m_AlreadyFocused = true;
            }
        }

        void Target_LostFocus(object sender, RoutedEventArgs e)
        {
            m_AlreadyFocused = false;
        }

        void Target_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!m_AlreadyFocused && (AssociatedObject.SelectionLength == 0 || AssociatedObject.SelectionLength == AssociatedObject.Text.Length) && OnMouseClick)
            {
                m_AlreadyFocused = true;
                AssociatedObject.SelectAll();
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
            var behaviors = i.Interaction.GetBehaviors(dpo);
            var existingBehavior = behaviors.FirstOrDefault(b => b.GetType() == typeof(SelectAllTextBoxBehavior)) as SelectAllTextBoxBehavior;

            if (!(bool)e.NewValue && existingBehavior != null)
            {
                behaviors.Remove(existingBehavior);
            }
            else if ((bool)e.NewValue && existingBehavior == null)
            {
                behaviors.Add(new SelectAllTextBoxBehavior() { OnMouseClick = GetSelectOnMouseClick(dpo) });
            }
        }

        static void OnSelectOnMouseClickChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = i.Interaction.GetBehaviors(dpo);
            var existingBehavior = behaviors.FirstOrDefault(b => b.GetType() == typeof(SelectAllTextBoxBehavior)) as SelectAllTextBoxBehavior;

            if (existingBehavior != null)
            {
                existingBehavior.OnMouseClick = (bool)e.NewValue;
            }
            else if ((bool)e.NewValue && existingBehavior == null)
            {
                SetIsEnabled(dpo, true);
                behaviors.Add(new SelectAllTextBoxBehavior() { OnMouseClick = true });
            }
        }

        #endregion "Boilerplate for XAML Attached Properties"
    }
}
