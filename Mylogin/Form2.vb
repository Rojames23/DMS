Public Class Form2
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim r As Integer

        r = MessageBox.Show("Are you sure to Log out?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If r = vbYes Then
            Form1.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Module1.ConnectToMongoDB()


            MessageBox.Show("Connection to MongoDB successful and data inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Form3
            .TopLevel = False
            Panel5.Controls.Add(Form3)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With schedule
            .TopLevel = False
            Panel5.Controls.Add(schedule)
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With CLIENTS
            .TopLevel = False
            Panel5.Controls.Add(CLIENTS)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With DOCTORS
            .TopLevel = False
            Panel5.Controls.Add(DOCTORS)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With INVENTORY
            .TopLevel = False
            Panel5.Controls.Add(INVENTORY)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class