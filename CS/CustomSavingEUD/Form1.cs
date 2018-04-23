using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;

namespace CustomSavingEUD
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        // Create an MDI (multi-document interface) controller instance.
        XRDesignMdiController mdiController;

        private void button1_Click(object sender, EventArgs e) {
            // Create a design form and get its MDI controller.
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;

            // Handle the DesignPanelLoaded event of the MDI controller,
            // to override the SaveCommandHandler for every loaded report.
            mdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

            // Open an empty report in the form.
            mdiController.OpenReport(new XtraReport1());

            // Show the form.
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null) {
                mdiController.ActiveDesignPanel.CloseReport();
            }
        }
        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e) {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }

        public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel) {
                this.panel = panel;
            }

            public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
            object[] args) {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
            ref bool useNextHandler) {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

            void Save() {
                // Write your custom saving here.
                // ...

                // For instance:
                panel.Report.SaveLayout("c:\\report1.repx");

                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;
            }
        }
    }
}