﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MicrosoftApiSelectDirectoryService.cs" company="WildGums">
//   Copyright (c) 2008 - 2018 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Controls.Services
{
    using System.Threading.Tasks;
    using Catel.Services;
    using Microsoft.WindowsAPICodePack.Dialogs;

    public class MicrosoftApiSelectDirectoryService : ISelectDirectoryService
    {
        #region Properties
        public string FileName { get; set; }
        public string Filter { get; set; }
        public string DirectoryName { get; private set; }
        public bool ShowNewFolderButton { get; set; }
        public string InitialDirectory { get; set; }
        public string Title { get; set; }
        #endregion

        #region ISelectDirectoryService Members
        public async Task<bool> DetermineDirectoryAsync()
        {
            var browserDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = Title,
                InitialDirectory = InitialDirectory
            };

            if (browserDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DirectoryName = browserDialog.FileName;
                return true;
            }

            DirectoryName = string.Empty;
            return false;
        }
        #endregion
    }
}
