using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Effects;

namespace CaliburnMicroWorkshop.Behaviours
{
    public class InteractivityBlurOnDisabled : Behavior<FrameworkElement>
    {
        public int BlurRadius
        {
            get { return (int)GetValue(BlurRadiusProperty); }
            set { SetValue(BlurRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BlurRadius. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlurRadiusProperty =
            DependencyProperty.Register("BlurRadius", typeof(int), typeof(FrameworkElement), new UIPropertyMetadata(0));



        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.IsEnabledChanged += AssociatedObjectIsEnabledChanged;
        }

        private void AssociatedObjectIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!AssociatedObject.IsEnabled)
                AssociatedObject.Effect = new BlurEffect() { Radius = BlurRadius };
            else
                AssociatedObject.Effect = null;
        }
    }
}