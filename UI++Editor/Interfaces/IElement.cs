﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UI__Editor.Interfaces
{
    public interface IElement
    {
        string ActionType { get; }
        bool HasSubChildren { get; }
        IElement Parent { get; set; }
        ViewModels.Actions.IAction ViewModel { get; set; }
        bool TVSelected { get; set; } // for the tree view, not optimal
        bool TVIsExpanded { get; set; } // for the tree view, not optimal
        XmlNode GenerateXML();
    }
}
