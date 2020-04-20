Imports System
Imports System.IO

Module Program

    Async Function media(dias As Integer, euros As Double, contador As Integer) As Task(Of String)
        Dim md As Integer
        Dim ms As Double

        md = dias / contador
        ms = euros / contador

        Return $"El salario medio es {md} y los dias de vacaciones medios son {ms}"
    End Function
    Private Function crearLog(linea As String)
        Dim ruta As String = "C:\datos\test.txt"

        If System.IO.File.Exists(ruta) = True Then
            Dim fs As StreamWriter = File.AppendText(ruta)



            fs.WriteLine(linea)
            fs.Close()

        Else

            Dim fs As FileStream = File.Create(ruta)


            Dim objWriter As New System.IO.StreamWriter(ruta)

            objWriter.Write(linea)
            objWriter.Close()

        End If
    End Function
    Private Function calcSueldo(cuenta As empleado) As String
        Dim dinero As Double = 1500
        If cuenta.edad < 18 Then
            Return "Edad insuficente para trabajar"
        Else
            If cuenta.edad <= 50 Then
                Return (dinero * 1.05).ToString
            Else
                If cuenta.edad <= 60 Then
                    Return (dinero * 1.1).ToString
                Else
                    Return (dinero * 1.5).ToString
                End If
            End If
        End If
    End Function

    Private Function calcVacaciones(cuenta As empleado) As Integer
        If cuenta.departamento = 1 Then
            If cuenta.antiguedad >= 2 And cuenta.antiguedad <= 6 Then
                Return 15
            Else
                If cuenta.antiguedad >= 7 Then
                    Return 20
                End If

            End If
        ElseIf cuenta.departamento = 2 Then
            If cuenta.antiguedad >= 2 And cuenta.antiguedad <= 6 Then
                Return 15
            Else
                If cuenta.antiguedad >= 7 Then
                    Return 25
                End If

            End If
        ElseIf cuenta.departamento = 3 Then
            If cuenta.antiguedad >= 2 And cuenta.antiguedad <= 6 Then
                Return 15
            Else
                If cuenta.antiguedad >= 7 Then
                    Return 30
                End If

            End If


        End If

    End Function
    Private Structure empleado
        Public nombre As String
        Public id As Integer
        Public edad As Integer
        Public departamento As Integer
        Public antiguedad As Integer
    End Structure

    Private Structure cuentas
        Public id As Integer
        Public contraseña As String
    End Structure

    Sub Main(args As String())
        Dim id As String
        Dim contraseña As String
        Dim emple As empleado
        Dim cuent As cuentas
        Dim registrado As Boolean = False
        Dim y As Integer

        Dim listaCuentas = New List(Of cuentas)
        Dim listaEmpleados = New List(Of empleado)
        id = 1

        While id <> 0
            registrado = False
            y = 0
            Console.WriteLine("Inicio de sesion:")
            Console.WriteLine("Introduzca su id")
            id = Console.ReadLine

            Console.WriteLine("Introduzca su contraseña")
            contraseña = Console.ReadLine

            For i As Integer = 0 To listaCuentas.Count - 1 Step 1
                cuent = listaCuentas.ElementAt(i)
                If cuent.id = id And cuent.contraseña = contraseña Then
                    registrado = True
                    Exit For
                Else
                    registrado = False
                End If
            Next

            If registrado = False And id <> 0 Then
                Console.WriteLine("Contraseña incorrecta o usuario inexistente, ¿Desea registrarse?")
                If Console.ReadLine = "si" Then
                    Console.WriteLine("Iniciando registro.")
                    Console.WriteLine("introduzca su nombre")
                    emple.nombre = Console.ReadLine

                    Console.WriteLine("introduzca su id")
                    emple.id = Console.ReadLine
                    cuent.id = emple.id

                    Console.WriteLine("introduzca su edad")
                    emple.edad = Console.ReadLine

                    Console.WriteLine("introduzca su departamento (Numero entre 1 y 3)")
                    emple.departamento = Console.ReadLine

                    Console.WriteLine("introduzca su antiguedad")
                    emple.antiguedad = Console.ReadLine

                    Console.WriteLine("introduzca su nueva contraseña")
                    cuent.contraseña = Console.ReadLine

                    listaEmpleados.Add(emple)
                    listaCuentas.Add(cuent)

                Else
                    Console.WriteLine("Vuelva a intentarlo")
                End If
            Else
                For i As Integer = 0 To listaEmpleados.Count - 1 Step 1
                    If id = listaEmpleados.ElementAt(i).id Then
                        Dim a As String = $"{listaEmpleados.ElementAt(i).nombre} ,{listaEmpleados.ElementAt(i).edad} ,{listaEmpleados.ElementAt(i).antiguedad} ,{calcVacaciones(listaEmpleados.ElementAt(i))} ,{calcSueldo(listaEmpleados.ElementAt(i))}"
                        Console.WriteLine(a)
                        crearLog(a)
                    End If
                Next

            End If

        End While

        Dim vactotal As Integer = 0
        Dim contador As Integer
        Dim sueltotal As Double = 0
        For i As Integer = 0 To listaEmpleados.Count - 1 Step 1
            vactotal += calcVacaciones(listaEmpleados.ElementAt(i))
            If calcSueldo(listaEmpleados.ElementAt(i)) <> "Edad insuficente para trabajar" Then
                sueltotal += Double.Parse(calcSueldo(listaEmpleados.ElementAt(i)))
            End If
            contador = i
        Next

        Console.WriteLine($"{media(vactotal, sueltotal, contador)}")




    End Sub
End Module
