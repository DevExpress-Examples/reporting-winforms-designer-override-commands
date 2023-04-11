using DevExpress.XtraReports.UserDesigner;
public class SaveCommandHandler : ICommandHandler {
    XRDesignPanel panel;

    public SaveCommandHandler(XRDesignPanel panel) {
        this.panel = panel;
    }

    public void HandleCommand(ReportCommand command,
    object[] args) {
        // Save the report.
        Save();
    }

    public bool CanHandleCommand(ReportCommand command,
    ref bool useNextHandler) {
        useNextHandler = !(command == ReportCommand.SaveFile ||
            command == ReportCommand.SaveFileAs);
        return !useNextHandler;
    }

    void Save() {
        // Write your custom method here.
        // ...

        // Example:
        panel.Report.SaveLayout("report1.repx");

        // Prevent the "Report has been changed" dialog from being shown.
        panel.ReportState = ReportState.Saved;
    }
}
