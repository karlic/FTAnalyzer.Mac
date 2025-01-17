// This file has been autogenerated from a class added in the UI designer.
using FTAnalyzer.Properties;

namespace FTAnalyzer.ViewControllers
{
    public partial class PreferencesViewController : NSViewController
    {
        public PreferencesViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            switch (Title)
            {
                case "File Handling Preferences":
                    LoadWithFiltersOutlet.Activated += LoadWithFiltersOutlet_Activated;
                    RetryFailedLinesOutlet.Activated += RetryFailedLinesOutlet_Activated;
                    ConvertDiacriticsOutlet.Activated += ConvertDicriticsOutlet_Activated;
                    SetFileHandlingSettings();
                    break;
                case "General Preferences":
                    UseBaptismDatesOutlet.Activated += UseBaptismDatesOutlet_Activated;
                    UseBurialDatesOutlet.Activated += UseBurialDatesOutlet_Activated;
                    AllowEmptyLocationsOutlet.Activated += AllowEmptyLocationsOutlet_Activated;
                    ShowDuplicateFactsOutlet.Activated += ShowDuplicateFactsOutlet_Activated;
                    //LooseBirthMinimumAgeOutlet.Activated += LooseBirthMinimumAgeOutlet_Activated;
                    AliasinNameDisplayOutlet.Activated += AliasinNameDisplayOutlet_Activated;
                    UseCountryFirstOutlet.Activated += UseCountryFirstOutlet_Activated;
                    ShowWorldEventsOutlet.Activated += ShowWorldEventsOutlet_Activated;
                    IgnoreUnknownFactTypeOutlet.Activated += IgnoreUnknownFactTypeOutlet_Activated;
                    FemaleUnknownOutlet.Activated += FemaleUnknownOutlet_Activated;
                    ShowMultiAncestorOutlet.Activated += ShowMultiAncestorOutlet_Activated;
                    SkipFixingLocationsOutlet.Activated += SkipFixingLocationsOutlet_Activated;
                    SetGeneralSettings();
                    break;
                case "Census Preferences":
                    TreatResidenceasCensusOutlet.Activated += TreatResidenceasCensusOutlet_Activated;
                    SlightlyInaccurateOutlet.Activated += SlightlyInaccurateOutlet_Activated;
                    FamilyCensusFactsOutlet.Activated += FamilyCensusFactsOutlet_Activated;
                    CompactCensusRefOutlet.Activated += CompactCensusRefOutlet_Activated;
                    AutoCreateCensusFactsOutlet.Activated += AutoCreateCensusFactsOutlet_Activated;
                    AutoCreateCensusLocationsOutlet.Activated += AutoCreateCensusLocationsOutlet_Activated;
                    HideMissingCensusOutlet.Activated += HideMissingCensusOutlet_Activated;
                    SkipCensusRefNotesOutlet.Activated += SkipCensusRefNotesOutlet_Activated;
                    SetCensusSettings();
                    break;
                case "Non Gedcom Date Preferences":
                    SetNonGedcomDateSettings();
                    break;
                default:
                    break;
            }
        }

        #region Census Settings
        void SetCensusSettings()
        {
            TreatResidenceasCensusOutlet.State = GeneralSettings.Default.UseResidenceAsCensus ? NSCellStateValue.On : NSCellStateValue.Off;
            SlightlyInaccurateOutlet.State = GeneralSettings.Default.TolerateInaccurateCensusDate ? NSCellStateValue.On : NSCellStateValue.Off;
            FamilyCensusFactsOutlet.State = GeneralSettings.Default.OnlyCensusParents ? NSCellStateValue.On : NSCellStateValue.Off;
            CompactCensusRefOutlet.State = GeneralSettings.Default.UseCompactCensusRef ? NSCellStateValue.On : NSCellStateValue.Off;
            AutoCreateCensusFactsOutlet.State = GeneralSettings.Default.AutoCreateCensusFacts ? NSCellStateValue.On : NSCellStateValue.Off;
            AutoCreateCensusLocationsOutlet.State = GeneralSettings.Default.AddCreatedLocations ? NSCellStateValue.On : NSCellStateValue.Off;
            HideMissingCensusOutlet.State = GeneralSettings.Default.HidePeopleWithMissingTag ? NSCellStateValue.On : NSCellStateValue.Off;
            SkipCensusRefNotesOutlet.State = GeneralSettings.Default.SkipCensusReferences ? NSCellStateValue.On : NSCellStateValue.Off;
        }

        void TreatResidenceasCensusOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.UseResidenceAsCensus = TreatResidenceasCensusOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void SlightlyInaccurateOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.TolerateInaccurateCensusDate = SlightlyInaccurateOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void FamilyCensusFactsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.OnlyCensusParents = FamilyCensusFactsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void CompactCensusRefOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.UseCompactCensusRef = CompactCensusRefOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void AutoCreateCensusFactsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.AutoCreateCensusFacts = AutoCreateCensusFactsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void AutoCreateCensusLocationsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.AddCreatedLocations = AutoCreateCensusLocationsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void HideMissingCensusOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.HidePeopleWithMissingTag = HideMissingCensusOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void SkipCensusRefNotesOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.SkipCensusReferences = SkipCensusRefNotesOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        #endregion

        #region File Handling

        void SetFileHandlingSettings()
        {
            LoadWithFiltersOutlet.State = FileHandling.Default.LoadWithFilters ? NSCellStateValue.On : NSCellStateValue.Off;
            RetryFailedLinesOutlet.State = FileHandling.Default.RetryFailedLines ? NSCellStateValue.On : NSCellStateValue.Off;
            ConvertDiacriticsOutlet.State = FileHandling.Default.ConvertDiacritics ? NSCellStateValue.On : NSCellStateValue.Off;
        }

        void LoadWithFiltersOutlet_Activated(object? sender, EventArgs e)
        {
            FileHandling.Default.LoadWithFilters = LoadWithFiltersOutlet.State == NSCellStateValue.On;
            FileHandling.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void RetryFailedLinesOutlet_Activated(object? sender, EventArgs e)
        {
            FileHandling.Default.RetryFailedLines = RetryFailedLinesOutlet.State == NSCellStateValue.On;
            FileHandling.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void ConvertDicriticsOutlet_Activated(object? sender, EventArgs e)
        {
            FileHandling.Default.ConvertDiacritics = ConvertDiacriticsOutlet.State == NSCellStateValue.On;
            FileHandling.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        #endregion

        #region General Settings

        void SetGeneralSettings()
        {
            UseBurialDatesOutlet.State = GeneralSettings.Default.UseBaptismDates ? NSCellStateValue.On : NSCellStateValue.Off;
            UseBurialDatesOutlet.State = GeneralSettings.Default.UseBurialDates ? NSCellStateValue.On : NSCellStateValue.Off;
            AllowEmptyLocationsOutlet.State = GeneralSettings.Default.AllowEmptyLocations ? NSCellStateValue.On : NSCellStateValue.Off;
            ShowDuplicateFactsOutlet.State = GeneralSettings.Default.MultipleFactForms ? NSCellStateValue.On : NSCellStateValue.Off;
            //LooseBirthMinimumAgeOutlet.IntValue = GeneralSettings.Default.MinParentalAge;
            AliasinNameDisplayOutlet.State = GeneralSettings.Default.ShowAliasInName ? NSCellStateValue.On : NSCellStateValue.Off;
            UseCountryFirstOutlet.State = GeneralSettings.Default.ReverseLocations ? NSCellStateValue.On : NSCellStateValue.Off;
            ShowWorldEventsOutlet.State = GeneralSettings.Default.ShowWorldEvents ? NSCellStateValue.On : NSCellStateValue.Off;
            IgnoreUnknownFactTypeOutlet.State = GeneralSettings.Default.IgnoreFactTypeWarnings ? NSCellStateValue.On : NSCellStateValue.Off;
            FemaleUnknownOutlet.State = GeneralSettings.Default.TreatFemaleSurnamesAsUnknown ? NSCellStateValue.On : NSCellStateValue.Off;
            ShowMultiAncestorOutlet.State = GeneralSettings.Default.ShowMultiAncestors ? NSCellStateValue.On : NSCellStateValue.Off;
            SkipFixingLocationsOutlet.State = GeneralSettings.Default.SkipFixingLocations ? NSCellStateValue.On : NSCellStateValue.Off;
        }

        void UseBaptismDatesOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.UseBaptismDates = UseBaptismDatesOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void UseBurialDatesOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.UseBurialDates = UseBurialDatesOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void AllowEmptyLocationsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.AllowEmptyLocations = AllowEmptyLocationsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void ShowDuplicateFactsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.MultipleFactForms = ShowDuplicateFactsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        //void LooseBirthMinimumAgeOutlet_Activated(object? sender, EventArgs e)
        //{
        //    GeneralSettings.Default.MinParentalAge = LooseBirthMinimumAgeOutlet.IntValue;
        //    GeneralSettings.Default.Save();
        //    GeneralSettings.Default.ReloadRequired = true;
        //}

        void AliasinNameDisplayOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.ShowAliasInName = AliasinNameDisplayOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void UseCountryFirstOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.ReverseLocations = UseCountryFirstOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void ShowWorldEventsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.ShowWorldEvents = ShowWorldEventsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void IgnoreUnknownFactTypeOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.IgnoreFactTypeWarnings = IgnoreUnknownFactTypeOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void FemaleUnknownOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.TreatFemaleSurnamesAsUnknown = FemaleUnknownOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        void ShowMultiAncestorOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.ShowMultiAncestors = ShowMultiAncestorOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
        }

        void SkipFixingLocationsOutlet_Activated(object? sender, EventArgs e)
        {
            GeneralSettings.Default.SkipFixingLocations = SkipFixingLocationsOutlet.State == NSCellStateValue.On;
            GeneralSettings.Default.Save();
            GeneralSettings.Default.ReloadRequired = true;
        }

        #endregion

        #region Non Gedcom Dates

        void SetNonGedcomDateSettings()
        {
            // set checkboxes according to loaded settings
        }

        #endregion
    }
}
