Imports DevExpress.XtraReports.UserDesigner

Public Class SaveCommandHandler
    Implements ICommandHandler

    Private panel As XRDesignPanel

    Public Sub New(ByVal panel As XRDesignPanel)
        Me.panel = panel
    End Sub

    Public Sub HandleCommand(ByVal command As ReportCommand, ByVal args() As Object) Implements ICommandHandler.HandleCommand
        ' Save the report.
        Save()
    End Sub

    Public Function CanHandleCommand(ByVal command As ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements ICommandHandler.CanHandleCommand
        useNextHandler = Not (command = ReportCommand.SaveFile OrElse command = ReportCommand.SaveFileAs OrElse command = ReportCommand.Closing)
        Return Not useNextHandler
    End Function

    Private Sub Save()
        ' Write your custom method here.
        ' ...

        ' EXample:
        panel.Report.SaveLayout("report1.repx")

        ' Prevent the "Report has been changed" dialog from being shown.
        panel.ReportState = ReportState.Saved
    End Sub
End Class
