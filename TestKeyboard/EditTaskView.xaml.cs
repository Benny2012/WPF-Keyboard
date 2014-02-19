using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFKeyboard.Keyboard;
using Microsoft.Surface.Presentation.Controls;


namespace WPFKeyboard.Tasks
{
    /// <summary>
    /// Interaktionslogik für Task.xaml
    /// </summary>
    public partial class EditTaskView : UserControl
    {
        private TextBox focusedElement;
        private OptionaElementChangedListener listener;

        public EditTaskView()
        {
            InitializeComponent();
            focusedElement = this.SurfaceTextBox;

        }

        /*
         * only for demonstration
         */
        public TextBox getFocusedElement()
        {
            return focusedElement;
        }

        /*
         * only for such a scenario necessary (with controller in between --> controller here is EditTask)
         */
        public void setOptionaElementChangedListener(OptionaElementChangedListener listener)
        {
            this.listener = listener;
        }


        /*
         * an element with no caret needed is focused
         */
        private void NotFocusableElement_TouchDown(object sender, TouchEventArgs e)
        {
            focusedElement = null;
            listener.onfocusedElementChanged();
        }

        private void TextBox_TouchUp(object sender, TouchEventArgs e)
        {
            focusedElement = sender as TextBox;
            listener.onfocusedElementChanged();
        }
    }

    public interface OptionaElementChangedListener
    {
        void onfocusedElementChanged();
    }
}
