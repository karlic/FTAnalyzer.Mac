﻿using System;

using AppKit;
using Foundation;
using FTAnalyzer.Utilities;

namespace FTAnalyzer
{
    public partial class GedcomDocumentViewController : NSViewController, IPrintViewController
    {
        AppDelegate App => (AppDelegate)NSApplication.SharedApplication.Delegate;

        public IProgress<string> Messages { get; }
        public IProgress<int> Sources { get; }
        public IProgress<int> Individuals { get; }
        public IProgress<int> Families { get; }
        public IProgress<int> Relationships { get; }
        public NSView PrintView { get; set; }

        public GedcomDocumentViewController(IntPtr handle) : base(handle)
        {
            Messages = new Progress<string>(AppendMessage);
            Sources = new Progress<int>(percent => SetProgress(_sourcesProgress, percent));
            Individuals = new Progress<int>(percent => SetProgress(_individualsProgress, percent));
            Families = new Progress<int>(percent => SetProgress(_familiesProgress, percent));
        	Relationships = new Progress<int>(percent => SetProgress(_relationshipsProgress, percent));
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Do any additional setup after loading the view.
            _titleLabel.Font = NSFont.FromFontName("Kunstler Script", 72.0f);
        }

        public void PreparePrintView(CustomPrintPanel panel)
        {
            NSTextView view = new NSTextView();
            PrintView.AddSubview(_statusTextView);
            PrintView.SetFrameSize(PrintView.IntrinsicContentSize);
            panel.Refresh = true;
        }

        #region Computed Properties
        /// <summary>
        /// Returns the delegate of the current running application
        /// </summary>
        /// <value>The this app.</value>
        public AppDelegate ThisApp => (AppDelegate)NSApplication.SharedApplication.Delegate;
        #endregion

        public override NSObject RepresentedObject => base.RepresentedObject;

        public void ClearAllProgress()
        {
            if (!NSThread.IsMain)
            {
                InvokeOnMainThread(ClearAllProgress);
                return;
            }
            _statusTextView.Value = string.Empty;
            _sourcesProgress.DoubleValue = 0;
            _individualsProgress.DoubleValue = 0;
            _familiesProgress.DoubleValue = 0;
            _relationshipsProgress.DoubleValue = 0;
        }

        void AppendMessage(string message)
        {
            if (!NSThread.IsMain)
            {
                InvokeOnMainThread(() => AppendMessage(message));
                return;
            }
            if (_statusTextView.Value == null)
                _statusTextView.Value = message;
            else
                _statusTextView.Value += message;
        }

        void SetProgress(NSProgressIndicator progressBar, int percent)
        {
            if (!NSThread.IsMain)
            {
                InvokeOnMainThread(() => SetProgress(progressBar, percent));
                return;
            }
            progressBar.DoubleValue = percent;
        }
    }
}
