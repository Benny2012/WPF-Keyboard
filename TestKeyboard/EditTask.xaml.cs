﻿using System;
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
using MuliTask.Keyboard;
using Microsoft.Surface.Presentation.Controls;

namespace MuliTask.Tasks
{
    /// <summary>
    /// Interaktionslogik für EditTask.xaml
    /// </summary>
    public partial class EditTask : UserControl, CustomKeyboardViewListener, OptionaElementChangedListener
    {
        
        private EditTaskView taskView;
        private Grid controllerGrid;

        /*
         * keyboard-variables
         */
        private TextBox focusedElement;
        private KeyboardController keyboardController;

        public EditTask()
        {
            InitializeComponent();

            controllerGrid = this.MainGrid;
            initAndSetView();
            initAndSetKeyboard();
            //optional
            keyboardController.setCustomKeyboardListener(this);
            taskView.setOptionaElementChangedListener(this);
        }


        private void initAndSetView()
        {
            taskView = new EditTaskView();
            controllerGrid.Children.Add(taskView);
            Grid.SetRow(taskView, 0);
            focusedElement = taskView.getFocusedElement();
        }

        /*
         * here is how you initialise the Keyboard
         */
        private void initAndSetKeyboard()
        {
            keyboardController = new KeyboardController(focusedElement);
            controllerGrid.Children.Add(keyboardController);
            Grid.SetRow(keyboardController, 1);
        }

        /*
         * interface-method(optional)
         */
        public void typedKey(string key)
        {
           
        }

        public void typedBackSpace()
        {
            
        }

        public void typedArrow(int arrowIndex)
        {
           
        }

        /*
         * to update when new focusedElement was clicked (optional)
         */
        public void onfocusedElementChanged()
        {
            keyboardController.setNewFocusedElement(taskView.getFocusedElement());
        }
    }
}
