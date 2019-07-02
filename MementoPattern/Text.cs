using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class Text
    {
        private string textStr;
        private Color textColor;
        private Font textFont;

        public string TextStr { get => textStr; set => textStr = value; }
        public Color TextColor { get => textColor; set => textColor = value; }
        public Font TextFont { get => textFont; set => textFont = value; }

        public void recoveryState(TextStateMemento textStateMemento)
        {
            this.textStr = textStateMemento.TextStr;
            this.textColor = textStateMemento.TextColor;
            this.textFont = textStateMemento.TextFont;
        }

        public TextStateMemento setState()
        {
            return new TextStateMemento(textStr, textColor, textFont);
        }
    }

    class TextStateMemento
    {
        private string textStr;
        private Color textColor;
        private Font textFont;

        public TextStateMemento(string textStr, Color textColor, Font textFont)
        {
            this.textStr = textStr;
            this.textColor = textColor;
            this.textFont = textFont;
        }

        public string TextStr { get => textStr; set => textStr = value; }
        public Color TextColor { get => textColor; set => textColor = value; }
        public Font TextFont { get => textFont; set => textFont = value; }
    }

    class TextStateCaretaker
    {
        private List<TextStateMemento> textStateMementos = new List<TextStateMemento>();
        private int currIndex = 0;

        public void addMemento(TextStateMemento textStateMemento)
        {
            if(textStateMementos.Count >= 10)
            {
                textStateMementos.RemoveAt(0);
            }
            textStateMementos.Add(textStateMemento);
            currIndex = textStateMementos.Count-1;
        }

        public TextStateMemento revocationMemento()
        {
            if(textStateMementos.Count > 0 && currIndex > 0)
            {
                return textStateMementos[--currIndex];
            }
            else
            {
                return null;
            }
        }

        public TextStateMemento renewalMemento()
        {
            if (textStateMementos.Count > 0 && currIndex < textStateMementos.Count-2)
            {
                return textStateMementos[++currIndex];
            }
            else
            {
                return null;
            }
        }

        public bool isRevocation()
        {
            if(textStateMementos.Count > 0 && currIndex > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRenewal()
        {
            if(textStateMementos.Count > 0 && currIndex < textStateMementos.Count - 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
