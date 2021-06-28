Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call mostrar empleado()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call limpiar()
    End Sub

    Sub limpiar()
        txtnoempleado.Clear()
        txtnombre.Clear()
        Txtfechanacimiento.Clear()
        txtapmat.Clear()
        txtappat.Clear()
        txtdireccion.Clear()
        txtdepto.Clear()
        Txtsueldo.Clear()
        txtbuscar.Clear()

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        conexion.open()
        Dim CMD. As New sqlcommand("guardar",conexion)
            CMD.commandType = CommandType.StoredProcedure
        whit CMD
            .parameters.Addwhitvalue
        ("@No_empleado", Me.txtempleado.text)
        ("@Ap_paterno", Me.txtappaterno.text)
        ("@Ap_Materno", Me.txtapmaterno.text)
        ("@Nombre", Me.txtnombre.text)
        ("@fecha_nacimiento", Me.txtfechanac.text)
        ("@Direccion", Me.txtdireccion.text)
        ("@depto", Me.txtdepartamento.text)
        ("@Sueldo", Me.txtsueldo.text)
        .ExecuteNonQuery()

        End Whit
            MsgBox("empleado agregado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "agregar")
        Call btnMostrarempleado()
        Call limpiar()
        txtnoempleado.Focus()
        conexion.close()

    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Call mostrar Empleado()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim Fila As DataGrindviewRow = DataGrindview1 current Row
        txtnoempleado.Text = CStr(Fila.cells(0).value)
        txtappat.Text = (Fila.cells(1).value)
        txtapmat.Text = (Fila.cells(2).value)
        txtnombre.Text = (Fila.cells(3).value)
        Txtfechanacimiento.Text = (Str(Fila.cells(4).value))
        txtdireccion.Text = (Fila.cells(5).value)
        txtdepto.Text = (Fila.cells(6).value)
        Txtsueldo.Text = (Str(Fila.cells(7).value))
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtbuscar = "" Then
            MsgBox("Debe escribir algo en el campo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Busqueda")

        ElseIf rbtnoempleado.checked Then
            txtbuscar.Focus()
            Dim Da As New SqlDataAdapter(consulta_empleado, conexion)
            Da.Selectedcommand.commandType = CommandType.StoredProcedure
            Da.selectedcommand Pameters.Addwhitvalue("@Variable no_empleado", Me.txtbuscar.Text)

Dim DT As New DataTable
            Da.Fill(DT)
            Me.DataGrindView1.Datasource = DT
            Call limpiar()

        ElseIf rbtnoempleado.checked Then
            txtbuscar.Focus()
            Da.selectedcommand.parameters.Addwhitvalue
("@variable departamento", Me.txtbuscar.text)

Else
            MsgBox("Debe seleccionar una opcion de busqueda", MsgBoxStyle.Information + MsgBoxStyle.Ok only, "Buscar")
            txtbuscar.Focus()
            Call limpiar()
        End If
    End Sub
End Class

Public Sub Mostrar empleado()
    Dim DA As New SqlDataAdapter("consulta", conexion)
    Dim DS As New DataSet
    DA fill(DS, "Empleado")
        DataGrindView.Datasource = DS.Tables("Empleado")
End Sub

Private Function conexion() As String
    Throw New NotImplementedException()
End Function
