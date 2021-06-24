'*********************************************
' Neina Cichon
' April 21, 2020
' Programming 1
' Payroll Program
'*********************************************

Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Closes the Program
        Close()

    End Sub

    'Open Hourly Form on Click
    Private Sub btnHourly_Click(sender As Object, e As EventArgs) Handles btnHourly.Click

        'Create New instance of frmHourly
        Dim Hourly As New frmHourly

        'show form modally
        Hourly.ShowDialog()

    End Sub

    Private Sub btnSalary_Click(sender As Object, e As EventArgs) Handles btnSalary.Click

        'Create New instance of frmSalary
        Dim Salary As New frmSalary

        'show form modally
        Salary.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        'Call Exit Button subroutine
        btnExit_Click(sender, e)

    End Sub

    Private Sub HourlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HourlyToolStripMenuItem.Click

        'Call Hourly Button subroutine
        btnHourly_Click(sender, e)

    End Sub

    Private Sub SalaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaryToolStripMenuItem.Click

        'Call Salary Button subroutine
        btnSalary_Click(sender, e)

    End Sub
End Class
