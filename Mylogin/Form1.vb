Imports MongoDB.Driver
Imports MongoDB.Bson
Imports BCrypt.Net

Public Class Form1
    Dim collection As IMongoCollection(Of BsonDocument)
    Private Sub linkaccnt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkaccnt.LinkClicked
        anima1.HideSync(p2)
        anima1.ShowSync(p3)
        l3.Text = "Create Account"
    End Sub

    Private Sub btnx_Click(sender As Object, e As EventArgs) Handles btnx.Click
        anima1.HideSync(p3)
        anima1.ShowSync(p2)
        l3.Text = "Authentication"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        anima1.ShowSync(l1)
        anima1.AnimationType = Guna.UI.Animation.AnimationType.HorizSlide
        anima1.ShowSync(l2)
        anima1.AnimationType = Guna.UI.Animation.AnimationType.HorizBlind
        anima1.ShowSync(l3)
        anima1.AnimationType = Guna.UI.Animation.AnimationType.HorizSlide
        anima1.ShowSync(p2)
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Dim name As String = BunifuMaterialTextbox1.Text
        Dim password As String = BunifuMaterialTextbox2.Text

        Try
            ' Establish MongoDB connection.
            Module1.ConnectToMongoDB()

            ' Retrieve the user data from MongoDB based on the entered username.
            Dim userDocument As BsonDocument = Module1.GetUserFromDatabase(Name)

            If userDocument IsNot Nothing Then
                ' Get the password stored in the database for the user.
                Dim passwordFromDatabase As String = userDocument.GetValue("password").ToString()

                ' Compare the entered password with the one stored in the database.
                If password = passwordFromDatabase Then
                    ' Password matches; login successful.
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Form2.Show()
                    Me.Hide()
                    BunifuMaterialTextbox1.Text = ""
                    BunifuMaterialTextbox2.Text = ""

                Else
                    ' Password doesn't match.
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' Clear the password TextBox.

                    BunifuMaterialTextbox2.Focus()
                End If
            Else
                ' User not found (username doesn't exist in the database).
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Clear the password TextBox.

            End If
        Catch ex As Exception
            ' Handle any exceptions during MongoDB connectivity or data retrieval.
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub GunaLabel1_Click(sender As Object, e As EventArgs) Handles GunaLabel1.Click
        Me.Dispose()

    End Sub

    Private Sub l2_Click(sender As Object, e As EventArgs) Handles l2.Click

    End Sub

    Private Sub GunaLabel2_Click(sender As Object, e As EventArgs) Handles GunaLabel2.Click
        Me.Close()

    End Sub

    Private Sub p2_Paint(sender As Object, e As PaintEventArgs) Handles p2.Paint

    End Sub

    Private Sub p3_Paint(sender As Object, e As PaintEventArgs) Handles p3.Paint

    End Sub

    Private Sub BunifuMaterialTextbox2_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox2.OnValueChanged
        If GunaCheckBox1.Checked = True Then
            BunifuMaterialTextbox2.isPassword = False

        Else
            BunifuMaterialTextbox2.isPassword = True


        End If
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged


    End Sub

    Private Sub BunifuMaterialTextbox3_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox3.OnValueChanged
        If GunaCheckBox2.Checked = True Then
            BunifuMaterialTextbox3.isPassword = False

        Else
            BunifuMaterialTextbox3.isPassword = True


        End If
    End Sub

    Private Sub BunifuMaterialTextbox5_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox5.OnValueChanged
        If GunaCheckBox2.Checked = True Then
            BunifuMaterialTextbox5.isPassword = False

        Else
            BunifuMaterialTextbox5.isPassword = True


        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub p1_Paint(sender As Object, e As PaintEventArgs) Handles p1.Paint

    End Sub

    Private Sub l3_Click(sender As Object, e As EventArgs) Handles l3.Click

    End Sub

    Private Sub l1_Click(sender As Object, e As EventArgs) Handles l1.Click

    End Sub

    Private Sub BunifuMaterialTextbox4_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox4.OnValueChanged

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        If BunifuMaterialTextbox3.Text = "" Or BunifuMaterialTextbox4.Text = "" Or BunifuMaterialTextbox5.Text = "" Then
            MessageBox.Show("ALL FIELDS REQUIRED!")
        Else

            Try

                Module1.ConnectToMongoDB()
                Dim username As String = BunifuMaterialTextbox4.Text
                Dim password As String = BunifuMaterialTextbox3.Text
                Dim confirmpassword As String = BunifuMaterialTextbox5.Text

                Dim admin As BsonDocument = New BsonDocument()
                admin.Add("name", username)
                admin.Add("password", password)
                admin.Add("confirm password", confirmpassword)
                If confirmpassword = password Then
                    Module1.InsertDataIntoMongoDB(admin)
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BunifuMaterialTextbox3.Text = ""
                    BunifuMaterialTextbox5.Text = ""
                    BunifuMaterialTextbox4.Text = ""
                    anima1.HideSync(p3)
                    anima1.ShowSync(p2)
                Else
                    MessageBox.Show("Passwords do not match. Please re-enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    username = ""
                    confirmpassword = ""

                End If
                BunifuMaterialTextbox3.Text = ""
                BunifuMaterialTextbox5.Text = ""
            Catch ex As Exception

                Throw New Exception("Error inserting data into MongoDB: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged

    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
End Class