// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using AppKit;
using Foundation;
using FTAnalyzer.DataSources;
using FTAnalyzer.Utilities;

namespace FTAnalyzer.ViewControllers
{
    public partial class LCReportsViewController : NSViewController
    {
        public LCReportsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ReportsTextBox.Value = "";
        }

        partial void VisitLostCousinsForumClicked(NSObject sender)
        {
            SpecialMethods.VisitWebsite("http://forums.lc");
        }

        partial void VisitLostCousinsWebsiteClicked(NSObject sender)
        {
            SpecialMethods.VisitWebsite("http://www.lostcousins.com/?ref=LC585149");
            Analytics.TrackAction(Analytics.LostCousinsAction, Analytics.LCWebLinkEvent);
        }

        partial void EW1841CensusClicked(NSObject sender)
        {
            string reportTitle = "1841 England & Wales Census Records on file";
            LostCousinsCensus(CensusDate.EWCENSUS1841, reportTitle);
        }

        partial void EW1881CensusClicked(NSObject sender)
        {
            string reportTitle = "1881 England & Wales Census Records on file";
            LostCousinsCensus(CensusDate.EWCENSUS1881, reportTitle);
        }

        partial void EW1911CensusClicked(NSObject sender)
        {
            string reportTitle = "1911 England & Wales Census Records on file";
            LostCousinsCensus(CensusDate.EWCENSUS1911, reportTitle);
        }

        partial void Scotland1881CensusClicked(NSObject sender)
        {
            string reportTitle = "1881 Scotland Census Records on file";
            LostCousinsCensus(CensusDate.SCOTCENSUS1881, reportTitle);
        }

        partial void Ireland1911CensusClicked(NSObject sender)
        {
            string reportTitle = "1911 Ireland Census Records on file";
            LostCousinsCensus(CensusDate.IRELANDCENSUS1911, reportTitle);
        }

        partial void Canada1880CensusClicked(NSObject sender)
        {
            string reportTitle = "1881 Canada Census Records on file";
            LostCousinsCensus(CensusDate.CANADACENSUS1881, reportTitle);
        }

        partial void US1880CensusClicked(NSObject sender)
        {
            string reportTitle = "1880 US Census Records on file";
            LostCousinsCensus(CensusDate.USCENSUS1880, reportTitle);
        }

        partial void US1940CensusClicked(NSObject sender)
        {
            string reportTitle = "1940 US Census Records on file";
            LostCousinsCensus(CensusDate.USCENSUS1940, reportTitle);
        }

        void LostCousinsCensus(CensusDate censusDate, string reportTitle)
        {
            Census census = new Census(censusDate, true);
            Predicate<CensusIndividual> relationFilter = RelationshipTypesOutlet.BuildFilter<CensusIndividual>(x => x.RelationType);
            Predicate<Individual> individualRelationFilter = RelationshipTypesOutlet.BuildFilter<Individual>(x => x.RelationType);
            census.SetupLCCensus(relationFilter, ShowAlreadyEnteredOutlet.State == NSCellStateValue.On, individualRelationFilter);
            if (ShowAlreadyEnteredOutlet.State == NSCellStateValue.On)
                census.ShowWindow($"{reportTitle} already entered into Lost Cousins website (includes entries with no country)");
            else
                census.ShowWindow($"{reportTitle} to enter into Lost Cousins website");
            Task.Run(() => Analytics.TrackActionAsync(Analytics.LostCousinsAction, Analytics.LCReportYearEvent, censusDate.BestYear.ToString()));
        }

        public void UpdateLostCousinsReport(ProgressController progressController)
        {
            IProgress<int> progress = new Progress<int>(percent => SetProgress(progressController, percent));
            InvokeOnMainThread(() =>
            {
                Predicate<Individual> relationFilter = RelationshipTypesOutlet.BuildFilter<Individual>(x => x.RelationType);
                string reportText = FamilyTree.Instance.UpdateLostCousinsReport(relationFilter, progress);
                ReportsTextBox.Value = reportText;
                var newtext = ReportsTextBox.String;
            });
        }

        public RelationshipTypesView RelationshipTypes => RelationshipTypesOutlet;

        void SetProgress(ProgressController progressController, int percent)
        {
            if (!NSThread.IsMain)
            {
                InvokeOnMainThread(() => SetProgress(progressController, percent));
                return;
            }
            progressController.ProgressBar = percent;
        }

        public void Clear()
        {
            ReportsTextBox.Value = string.Empty;
        }
    }
}
