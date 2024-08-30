Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        'crear objetos excel
        Dim excelApp As New Application()
        Dim workbook As Workbook = Nothing
        Dim worksheet As Worksheet = Nothing

        Try
            'abrir el archivo excel
            workbook = excelApp.Workbooks.Open("C:\Users\Joao\Documents\Visual Studio 2019\EPE1-Joao_Ureta\Lista.xls")
            worksheet = workbook.Sheets(1)

            'limpiar el comboBox
            cmbProductos.Items.Clear()
            'indice combobox
            cmbProductos.Items.Add("Seleccione un código")

            'recorrer las filas del excel
            Dim row As Integer = 2
            While worksheet.Cells(row, 1).Value IsNot Nothing
                cmbProductos.Items.Add(worksheet.Cells(row, 1).Value.ToString())
                row += 1
            End While

            '"Seleccione un código" como indice
            cmbProductos.SelectedIndex = 0

            'deshabilitar el boton
            btnCargar.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar el archivo: " & ex.Message)
        Finally
            'liberar recursos
            workbook.Close(False)
            Marshal.ReleaseComObject(workbook)
            excelApp.Quit()
            Marshal.ReleaseComObject(excelApp)
        End Try
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

        If cmbProductos.SelectedIndex > 0 Then
            'crear objetos Excel
            Dim excelApp As New Application()
            Dim workbook As Workbook = Nothing
            Dim worksheet As Worksheet = Nothing

            Try
                'abrir el archivo excel
                workbook = excelApp.Workbooks.Open("C:\Users\Joao\Documents\Visual Studio 2019\EPE1-Joao_Ureta\Lista.xls")
                worksheet = workbook.Sheets(1)

                'obtener el indice
                Dim selectedIndex As Integer = cmbProductos.SelectedIndex + 1 ' Ajuste por "Seleccione un código"

                'mostrar datos
                txtDescripcion.Text = worksheet.Cells(selectedIndex, 2).Value.ToString()
                txtPrecio.Text = worksheet.Cells(selectedIndex, 6).Value.ToString()
                txtStock.Text = worksheet.Cells(selectedIndex, 7).Value.ToString()

            Catch ex As Exception
                MessageBox.Show("Error al cargar los datos del producto: " & ex.Message)
            Finally
                'liberar recursos
                workbook.Close(False)
                Marshal.ReleaseComObject(workbook)
                excelApp.Quit()
                Marshal.ReleaseComObject(excelApp)
            End Try
        Else
            'al seleccionar "Seleccione un código" limpia combobox
            txtDescripcion.Clear()
            txtPrecio.Clear()
            txtStock.Clear()
        End If
    End Sub
End Class

