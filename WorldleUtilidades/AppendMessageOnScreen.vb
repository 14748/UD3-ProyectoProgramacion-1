Imports System.Drawing
Imports System.Windows.Forms

Public Class AppendMessageOnScreen
    Private animationTimer As Timer
    Private labelsToAnimate As New List(Of Label)

    Public Sub New()
        animationTimer = New Timer With {.Interval = 10}
        AddHandler animationTimer.Tick, AddressOf AnimateLabel
    End Sub

    Public Sub CreateAnimatedLabel(targetForm As Form, ByVal text As String, x As Integer, y As Integer)
        If labelsToAnimate.Count < 4 Then
            Dim newLabel As New Label With {
            .Text = text,
            .BackColor = ColorTranslator.FromHtml("#d7dadc"),
            .ForeColor = Color.Black,
            .Location = New Point(x, y),
            .Font = New Font("Arial", 24, FontStyle.Bold),
            .AutoSize = True
        }

            targetForm.Controls.Add(newLabel)
            newLabel.Location = New Point(x - newLabel.Width / 2, y - newLabel.Height + (60 * labelsToAnimate.Count))
            newLabel.BringToFront()
            labelsToAnimate.Add(newLabel)

            ' Start animation if it isn't already running
            animationTimer.Start()
        End If
    End Sub

    Private Sub AnimateLabel(ByVal sender As Object, ByVal e As EventArgs)
        If labelsToAnimate.Count > 0 Then
            ' Get the last label in the list
            Dim label = labelsToAnimate(labelsToAnimate.Count - 1)

            Dim targetForm = TryCast(label.Parent, Form)

            label.ForeColor = Color.FromArgb(Math.Max(label.ForeColor.A - 5, 0), label.ForeColor.R, label.ForeColor.G, label.ForeColor.B)
            Debug.WriteLine(label.ForeColor.A)
            If label.ForeColor.A = 0 Then
                targetForm.Controls.Remove(label)
                label.Dispose()
                labelsToAnimate.RemoveAt(labelsToAnimate.Count - 1) ' Remove the last label in the list
            End If

            ' Stop the animation if there are no more labels to remove
            If labelsToAnimate.Count = 0 Then
                animationTimer.Stop()
            End If
        End If
    End Sub

End Class
