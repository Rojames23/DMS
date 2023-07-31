Public Class DOCTORS

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        adding_doctor.Show()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged




    End Sub

    Private Sub DOCTORS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        module1.ConnectToMongoDB()
        LoadDataFromMongoDB()








    End Sub

    Private Sub LoadDataFromMongoDB()
        Dim itemList As List(Of String) = Module1.LoadDataFromMongoDB()

        For Each itemName As String In itemList
            ListView1.Items.Add(itemName)
        Next


        ' Refresh the ListView to display the changes
        ListView1.Refresh()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListView1.Clear()
        LoadDataFromMongoDB()
        ListView1.Refresh()


    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class