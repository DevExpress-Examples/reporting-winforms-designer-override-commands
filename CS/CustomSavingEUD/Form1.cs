using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;

namespace CustomSavingEUD {
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

            // Override the Open Command.
            mdiController.AddCommandHandler(new OpenCommandHandler());

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
            // Override the Save Command.
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }
    }
}
