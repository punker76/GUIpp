﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI__Editor.Interfaces
{
    public interface IInput : IElement
    {
        ViewModels.Actions.Children.IInput ChildViewModel { get; set; }
    }
}
