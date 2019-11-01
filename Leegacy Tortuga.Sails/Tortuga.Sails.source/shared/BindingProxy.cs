using System;
using System.Linq;
using System.Windows;

namespace Tortuga.Sails
{
    /// <summary>
    /// A binding proxy allows a bindin expression to be used in a resource dictionary.
    /// </summary>
    /// <example>
    /// &lt;DataGrid.Resources&gt;
    ///        &lt;sails:BindingProxy x:Key="proxy" Data="{Binding}" /&gt;
    /// &lt;/DataGrid.Resources&gt;
    /// </example>
    public class BindingProxy : Freezable
    {
        /// <summary>
        /// When implemented in a derived class, creates a new instance of the <see cref="T:System.Windows.Freezable" /> derived class.
        /// </summary>
        /// <returns>The new instance.</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        /// <summary>
        /// Data-bindable property.
        /// </summary>
        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DataProperty =
    DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}