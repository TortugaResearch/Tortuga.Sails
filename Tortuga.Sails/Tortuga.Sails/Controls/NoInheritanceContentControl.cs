using System.Windows;
using System.Windows.Controls;

namespace Tortuga.Sails
{
    /// <summary>
    /// Whatever this control wraps will not inherit styles from its parent.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ContentControl" />
    public class NoInheritanceContentControl : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoInheritanceContentControl"/> class.
        /// </summary>
        public NoInheritanceContentControl()
        {
            InheritanceBehavior = InheritanceBehavior.SkipAllNow;
        }
    }
}
