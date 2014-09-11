using System.Windows.Input;

namespace Broobu.FindStation.UI.Controls
{
    /// <summary>
    /// Interaction logic for FindStationView.xaml
    /// </summary>
    public partial class FindStationView 
    {
        public FindStationView()
        {
            InitializeComponent();
        }


        protected override void OnFirstTimeRender()
        {
            DataContext = new FindStationViewModel();
            base.OnFirstTimeRender();
            //((FindStationViewModel)DataContext).PropertyChanged += (s, e) =>
            //{
            //};
        }


        private void UIElement_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            ((FindStationViewModel) DataContext).CallId = e.Text;
        }
    }
}
