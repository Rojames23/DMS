Imports MongoDB.Driver
Imports MongoDB.Bson
Imports BCrypt.Net

Module Module1

    Dim client As MongoClient
    Dim database As IMongoDatabase
    Dim collection As IMongoCollection(Of BsonDocument)
    Dim collect As IMongoCollection(Of BsonDocument)

    Public Sub ConnectToMongoDB()
        Try
            Dim connectionString As String = "mongodb+srv://capstone12023:caps2023tone@cluster0.vwa9od5.mongodb.net"
            client = New MongoClient(connectionString)
            database = client.GetDatabase("dentalManagementSystemDB")
            collection = database.GetCollection(Of BsonDocument)("admin")
            collect = database.GetCollection(Of BsonDocument)("doctor")
        Catch ex As Exception
            Throw New Exception("Error connecting to MongoDB: " & ex.Message)
        End Try
    End Sub

    Public Sub InsertDataIntoMongoDB(admin As BsonDocument)
        Try
            If collection IsNot Nothing Then
                collection.InsertOne(admin)
            Else
                Throw New Exception("MongoDB collection is not initialized.")
            End If
        Catch ex As Exception
            Throw New Exception("Error inserting data into MongoDB: " & ex.Message)
        End Try
    End Sub
    Public Sub doctorMongoDB(doctor As BsonDocument)
        Try
            If collect IsNot Nothing Then
                collect.InsertOne(doctor)
            Else
                Throw New Exception("MongoDB collection is not initialized.")
            End If
        Catch ex As Exception
            Throw New Exception("Error inserting data into MongoDB: " & ex.Message)
        End Try
    End Sub

    Public Function GetUserFromDatabase(name As String) As BsonDocument
        Try
            ' Create the filter directly without using Eq.
            Dim filter As FilterDefinition(Of BsonDocument) = New BsonDocument("name", name)
            Dim userDocument = collection.Find(filter).FirstOrDefault()

            Return userDocument
        Catch ex As Exception
            ' Handle any exceptions here (e.g., connection issues).
            MessageBox.Show("Error retrieving user data from the database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Function LoadDataFromMongoDB() As List(Of String)
        Dim collect As String = "doctor" ' Replace "doctor" with the actual collection name

        Dim col As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)(collect)

        ' Assuming your collection contains documents with fields named "LAST NAME," "FIRST NAME," "ADDRESS," "GMAIL," and "CONTACT"
        Dim projection = New BsonDocument()
        projection.Add("LAST NAME", 1)
        projection.Add("FIRST NAME", 1)
        projection.Add("ADDRESS", 1)
        projection.Add("GMAIL", 1)
        projection.Add("CONTACT", 1)

        Dim cursor As IFindFluent(Of BsonDocument, BsonDocument) = col.Find(New BsonDocument()).Project(projection)
        Dim items As List(Of BsonDocument) = cursor.ToList()

        Dim itemList As New List(Of String)()

        For Each item As BsonDocument In items
            ' Check if the required fields exist in the document
            If item.Contains("LAST NAME") AndAlso
               item.Contains("FIRST NAME") AndAlso
               item.Contains("ADDRESS") AndAlso
               item.Contains("GMAIL") AndAlso
               item.Contains("CONTACT") AndAlso
               item("CONTACT").IsString Then

                Dim lastName As String = item("LAST NAME").ToString()
                Dim firstName As String = item("FIRST NAME").ToString()
                Dim address As String = item("ADDRESS").ToString()
                Dim gmail As String = item("GMAIL").ToString()
                Dim contact As String = item("CONTACT").ToString()

                ' Now you can use these values to display or process the data as needed

                itemList.Add(lastName)
                itemList.Add(firstName)
                itemList.Add(address)
                itemList.Add(gmail)
                itemList.Add(contact)

            Else
                ' Handle cases where required fields are missing or not a string (optional)
                ' For example, you could skip the item or handle it in a different way.

            End If

        Next

        Return itemList


    End Function

End Module


