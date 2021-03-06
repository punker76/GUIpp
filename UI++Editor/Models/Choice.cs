﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Models
{
    public class Choice : PropertyChangedBase, IElement, IChildElement
    {
        public ViewModels.Actions.IAction ViewModel { get; set; }
        public IElement Parent { get; set; }
        public bool HasSubChildren { get { return false; } }
        public string ActionType { get { return "Choice"; } }
        public string[] ValidParents { get; set; } = { "InputChoice" };
        public string[] ValidChildren { get; set; }
        public string Option { get; set; } // required
        public string Value { get; set; }
        public string AlternateValue { get; set; }
        public string Condition { get; set; }

        public Choice(IElement p)
        {
            Parent = p;
            ViewModel = new ViewModels.Actions.Children.ChoiceViewModel(this);
        }

        // Code to handle TreeView Selection
        private bool _TVSelected = false;
        public bool TVSelected
        {
            get { return _TVSelected; }
            set
            {
                _TVSelected = value;
                NotifyOfPropertyChange(() => TVSelected);
            }
        }

        private bool _TVIsExpanded = true;
        public bool TVIsExpanded
        {
            get { return _TVIsExpanded; }
            set
            {
                _TVIsExpanded = value;
                NotifyOfPropertyChange(() => TVIsExpanded);
            }
        }
        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Choice", null);
            XmlAttribute option = d.CreateAttribute("Option");
            XmlAttribute value = d.CreateAttribute("Value");
            XmlAttribute alternateValue = d.CreateAttribute("AlternateValue");
            XmlAttribute condition = d.CreateAttribute("Condition");

            // Set Attribute Values
            option.Value = Option;
            value.Value = Value;
            alternateValue.Value = AlternateValue;
            condition.Value = Condition;

            // Append Attribute
            output.Attributes.Append(option);
            if (!string.IsNullOrEmpty(Value))
            {
                output.Attributes.Append(value);
            }
            if(!string.IsNullOrEmpty(AlternateValue))
            {
                output.Attributes.Append(alternateValue);
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                output.Attributes.Append(condition);
            }

            return output;
        }
    }
}
