Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UserDesigner

Namespace CustomSavingEUD
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        ' Create an MDI (multi-document interface) controller instance.
        Private mdiController As XRDesignMdiController

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a design form and get its MDI controller.
            Dim form As New XRDesignForm()
            mdiController = form.DesignMdiController

            ' Handle the DesignPanelLoaded event of the MDI controller,
            ' to override the SaveCommandHandler for every loaded report.
            AddHandler mdiController.DesignPanelLoaded, AddressOf mdiController_DesignPanelLoaded

            ' Open an empty report in the form.
            mdiController.OpenReport(New XtraReport1())

            ' Show the form.
            form.ShowDialog()
            If mdiController.ActiveDesignPanel IsNot Nothing Then
                mdiController.ActiveDesignPanel.CloseReport()
            End If
        End Sub
        Private Sub mdiController_DesignPanelLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
            Dim panel As XRDesignPanel = DirectCast(sender, XRDesignPanel)
            panel.AddCommandHandler(New SaveCommandHandler(panel))
        End Sub

        Public Class SaveCommandHandler
            Implements DevExpress.XtraReports.UserDesigner.ICommandHandler

            Private panel As XRDesignPanel

            Public Sub New(ByVal panel As XRDesignPanel)
                Me.panel = panel
            End Sub

            Public Sub HandleCommand(ByVal command As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal args() As Object) Implements ICommandHandler.HandleCommand
                ' Save the report.
                Save()
            End Sub

            Public Function CanHandleCommand(ByVal command As DevExpress.XtraReports.UserDesigner.ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements ICommandHandler.CanHandleCommand
                useNextHandler = Not (command = ReportCommand.SaveFile OrElse command = ReportCommand.SaveFileAs OrElse command = ReportCommand.Closing)
                Return Not useNextHandler
            End Function

            Private Sub Save()
                ' Write your custom saving here.
                ' ...

                ' For instance:
                panel.Report.SaveLayout("c:\report1.repx")

                ' Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved
            End Sub
        End Class
    End Class
End Namespace