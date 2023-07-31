Imports MongoDB.Driver
Imports MongoDB.Bson
Public Class adding_doctor

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BunifuMaterialTextbox1.Text = "" Or BunifuMaterialTextbox2.Text = "" Or BunifuMaterialTextbox3.Text = "" Or BunifuMaterialTextbox4.Text = "" Or BunifuMaterialTextbox3.Text = "" Or BunifuMaterialTextbox3.Text = "" Then

            MessageBox.Show("ALL FIELDS REQUIRED!")
        Else

            Try
                Module1.ConnectToMongoDB()
                Dim lastname As String = BunifuMaterialTextbox1.Text
                Dim firstname As String = BunifuMaterialTextbox2.Text
                Dim address As String = BunifuMaterialTextbox3.Text
                Dim gmail As String = BunifuMaterialTextbox4.Text
                Dim contact As String = BunifuMaterialTextbox5.Text
                Dim specialty As String = BunifuMaterialTextbox6.Text


                Dim doctor As BsonDocument = New BsonDocument()
                doctor.Add("LAST NAME", lastname)
                doctor.Add("FIRST NAME", firstname)
                doctor.Add("ADDRESS", address)
                doctor.Add("GMAIL", gmail)
                doctor.Add("CONTACT", contact)
                doctor.Add("SPECIALTY", specialty)
                Module1.doctorMongoDB(doctor)
                Me.Close()
                MessageBox.Show("SUCCESSFULLY SAVED!")
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub GunaLabel2_Click(sender As Object, e As EventArgs) Handles GunaLabel2.Click
        Me.Hide()
    End Sub
End Class