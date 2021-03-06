﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindableRichTextBox.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Controls.Example.ViewModels
{
    using System.Windows.Documents;
    using System.Windows.Media;
    using Catel;
    using Catel.MVVM;
    using Orc.Controls.Services;

    public class BindableRichTextBoxViewModel : ViewModelBase
    {
        #region Constructors
        public BindableRichTextBoxViewModel()
        {
            AccentColorBrush = Controls.ThemeHelper.GetAccentColorBrush();
            FlowDoc = CreateFlowDocument("This is example text colored with AccentColor");

            ClearText = new Command(OnClearText);
        }
        #endregion

        #region Properties
        public FlowDocument FlowDoc { get; set; }

        public bool UseAccentText { get; set; }

        [ObsoleteEx(TreatAsErrorFromVersion = "3.0", RemoveInVersion = "4.0", Message = "Use AccentColorBrush markup extension instead")]
        public Brush AccentColorBrush { get; set; }

        public Command ClearText { get; set; }
        #endregion

        #region Methods
        private void OnClearText()
        {
            FlowDoc = CreateFlowDocument();
        }

        private FlowDocument CreateFlowDocument(string text = null)
        {
            var flowDoc = new FlowDocument();
            var exampleParagraph = new Paragraph(new Run(text ?? string.Empty));

            if (UseAccentText)
            {
                exampleParagraph.Foreground = AccentColorBrush.Clone();
            }

            flowDoc.Blocks.Add(exampleParagraph);

            return flowDoc;
        }
        #endregion
    }
}
