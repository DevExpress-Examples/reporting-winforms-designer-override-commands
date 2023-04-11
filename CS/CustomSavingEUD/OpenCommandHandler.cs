using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;

public class OpenCommandHandler : ICommandHandler {
    public OpenCommandHandler() {
    }

    public void HandleCommand(ReportCommand command,
    object[] args) {
        switch (command) {
            case ReportCommand.OpenFile:
                Open();
                break;
        }
    }

    public bool CanHandleCommand(ReportCommand command,
    ref bool useNextHandler) {
        useNextHandler = !(command == ReportCommand.OpenFile);
        return !useNextHandler;
    }

    void Open() {
        MessageBox.Show("Open");
    }
}
