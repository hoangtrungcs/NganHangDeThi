using System;
using Telerik.WinControls;
using Telerik.WinControls.Themes;

namespace NganHangDeThi
{
    public partial class frmTheme : BaseForm
    {
        public frmTheme()
        {
            InitializeComponent();
        }

        private void frmTheme_Load(object sender, EventArgs e) {

        }

        private void ChangeApplicationTheme(string themeName) {
            switch (themeName) {
                case "HighContrastBlackTheme":
                    new HighContrastBlackTheme();
                    break;
                case "Office2010Black":
                    new Office2010BlackTheme();
                    break;
                case "Office2010Blue":
                    new Office2010BlueTheme();
                    break;
                case "Office2010Silver":
                    new Office2010SilverTheme();
                    break;
                case "TelerikMetroTheme":
                    new TelerikMetroTheme();
                    break;
                case "TelerikMetroBlueTheme":
                    new TelerikMetroBlueTheme();
                    break;
                case "Windows7Theme":
                    new Windows7Theme();
                    break;
            }

            ThemeResolutionService.ApplicationThemeName = themeName;
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            ChangeApplicationTheme("HighContrastBlackTheme");
        }

        private void radButtonElement2_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("Office2010Black");
        }

        private void radButtonElement3_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("Office2010Blue");
        }

        private void radButtonElement4_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("Office2010Silver");
        }

        private void radButtonElement5_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("TelerikMetroTheme");
        }

        private void radButtonElement6_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("TelerikMetroBlueTheme");
        }

        private void radButtonElement7_Click(object sender, EventArgs e) {
            ChangeApplicationTheme("Windows7Theme");
        }

        public override void Save() {
           // NOP
        }


        public void Create() {
            throw new NotImplementedException();
        }

        public override void Add() {
            throw new NotImplementedException();
        }

        public override void Edit() {
            throw new NotImplementedException();
        }

        public override void Cancel() {
            throw new NotImplementedException();
        }


        public override void Delete() {
            throw new NotImplementedException();
        }
    }
}
