﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace DisabledEditors
{
    public class MyRadDropDownList : RadDropDownList
    {
        MyTextBox mtb = new MyTextBox();
        RadTextBoxItem tbi;

        protected override void CreateChildItems(Telerik.WinControls.RadElement parent)
        {
            base.CreateChildItems(parent);

            tbi = new RadTextBoxItem(mtb);
            mtb.Font = this.Font;
            this.DropDownListElement.TextBox.Children.Add(tbi);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!this.Enabled)
            {
                tbi.Text = this.Text;
                this.DropDownListElement.TextBox.TextBoxItem.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }
            else
            {
                this.DropDownListElement.TextBox.TextBoxItem.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }

            base.OnEnabledChanged(e);
        }

        public override string ThemeClassName
        {
            get
            {
                return typeof(RadTextBox).FullName;
            }
        }

    }
}