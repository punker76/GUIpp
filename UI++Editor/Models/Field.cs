﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Models
{
    public class Field : PropertyChangedBase, IElement
    {
        public ViewModels.Actions.IAction ViewModel { get; set; }
        public IElement Parent { get; set; }
        public bool HasSubChildren { get { return false; } }
        public string ActionType { get { return "Field"; } }
        public string Name { get; set; } // required - must be Username, Password, or Domain
        public string Hint { get; set; }
        public string List { get; set; }
        public string Prompt { get; set; }
        public string Question { get; set; }
        public bool ReadOnly { get; set; } = false;
        public string RegEx { get; set; }

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
            XmlNode output = d.CreateNode("element", "Field", null);
            XmlAttribute name = d.CreateAttribute("Name");
            XmlAttribute hint = d.CreateAttribute("Hint");
            XmlAttribute list = d.CreateAttribute("List");
            XmlAttribute prompt = d.CreateAttribute("Prompt");
            XmlAttribute question = d.CreateAttribute("Question");
            XmlAttribute readOnly = d.CreateAttribute("ReadOnly");
            XmlAttribute regEx = d.CreateAttribute("RegEx");

            // Set Attribute Values
            name.Value = Name;
            hint.Value = Hint;
            list.Value = List;
            prompt.Value = Prompt;
            question.Value = Question;
            readOnly.Value = ReadOnly.ToString();
            regEx.Value = RegEx;

            // Append Attributes
            output.Attributes.Append(name);
            if (!string.IsNullOrEmpty(Hint))
            {
                output.Attributes.Append(hint);
            }
            if (!string.IsNullOrEmpty(List))
            {
                output.Attributes.Append(list);
            }
            if (!string.IsNullOrEmpty(Prompt))
            {
                output.Attributes.Append(prompt);
            }
            if (!string.IsNullOrEmpty(Question))
            {
                output.Attributes.Append(question);
            }
            output.Attributes.Append(readOnly);
            if (!string.IsNullOrEmpty(RegEx))
            {
                output.Attributes.Append(regEx);
            }

            return output;
        }
    }
}
