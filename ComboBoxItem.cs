using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    class ComboBoxItem
    {
        public object Value;
        public string Text;

        public ComboBoxItem(object oValue,
                            string sText)
        {
            Value = oValue;
            Text = sText;
        }

        public override string ToString()
        {
            return Text;
        }
    
    }
}
