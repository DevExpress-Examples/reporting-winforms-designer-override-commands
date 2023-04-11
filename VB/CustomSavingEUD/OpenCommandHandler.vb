Imports DevExpress.XtraReports.UserDesigner

Public Class OpenCommandHandler
	Implements ICommandHandler

	Public Sub New()
	End Sub

	Public Sub HandleCommand(ByVal command As ReportCommand, ByVal args() As Object) Implements ICommandHandler.HandleCommand
		Select Case command
			Case ReportCommand.OpenFile
				Open()
		End Select
	End Sub

	Public Function CanHandleCommand(ByVal command As ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements ICommandHandler.CanHandleCommand
		useNextHandler = Not (command = ReportCommand.OpenFile)
		Return Not useNextHandler
	End Function

	Private Sub Open()
		MessageBox.Show("Open")
	End Sub
End Class
