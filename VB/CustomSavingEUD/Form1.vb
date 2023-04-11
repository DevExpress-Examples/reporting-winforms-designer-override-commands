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

            'Override the Open Command.
            mdiController.AddCommandHandler(New OpenCommandHandler())

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
    End Class
End Namespace
