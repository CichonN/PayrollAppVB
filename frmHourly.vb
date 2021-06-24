'*********************************************
' Neina Cichon
' April 21, 2020
' Payroll Program
'*********************************************

Public Class frmHourly

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Closes the Hourly Window
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'Clears out textboxes
        txtFirstName.Clear()
        txtLastName.Clear()
        txtPreviousEarnings.Clear()
        txtWage.Clear()
        txtHours.Clear()

        'Clear Combobox
        cboState.SelectedIndex = -1

        'Clear out ListBox
        lstResults.Items.Clear()

        'Puts Focus back on first textbox
        txtFirstName.Focus()

    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click


        'Declare Variables
        Dim dblNetPay As Double
        Dim dblGross As Double
        Dim dblFedTax As Double
        Dim dblStateTax As Double
        Dim dblFICA As Double
        Dim dblWage As Double
        Dim dblHours As Double
        Dim dblPreviousEarnings As Double
        Dim strFirstName As String
        Dim strLastName As String

        'Set backcolors back to white in case of error
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtPreviousEarnings.BackColor = Color.White
        txtWage.BackColor = Color.White
        txtHours.BackColor = Color.White
        cboState.BackColor = Color.White



        If ValidateInput(strFirstName, strLastName, dblPreviousEarnings, dblWage, dblHours, cboState) Then

            'Call Calculation Procedures
            dblGross = CalcGrossPay(dblWage, dblHours)
            dblFICA = CalcFICA(dblPreviousEarnings, dblGross)
            dblStateTax = CalcStateTax(cboState, dblGross)
            dblFedTax = CalcFedTax(dblGross)
            dblNetPay = CalcNetPay(dblGross, dblFICA, dblStateTax, dblFedTax)

            'Call Display
            Display(dblNetPay, dblFICA, dblStateTax, dblFedTax, dblGross)

            'Display proper case for names in textboxes
            txtFirstName.Text = StrConv(txtFirstName.Text, vbProperCase)
            txtLastName.Text = StrConv(txtLastName.Text, vbProperCase)

            'Display Currency for Wage and Previous Earnings
            txtPreviousEarnings.Text = FormatCurrency(txtPreviousEarnings.Text)
            txtWage.Text = FormatCurrency(txtWage.Text)

        End If

    End Sub

    Function ValidateInput(ByRef FirstName As String, ByRef LastName As String, ByRef PreviousEarnings As Double, ByRef Wage As Double, ByRef Hours As Double, ByRef States As ComboBox) As Boolean

        'Validate all input 
        If ValidateFirstName(FirstName) = True Then
            If ValidateLastName(LastName) = True Then
                If ValidatePreviousEarnings(PreviousEarnings) = True Then
                    If ValidateWage(Wage) = True Then
                        If ValidateHrsWorked(Hours) = True Then
                            If ValidateStates(States) = True Then
                                Return True
                            Else
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
            Return False
        End If


    End Function


    'Create Function to Validate First Name
    Function ValidateFirstName(ByRef FirstName As String) As Boolean

        'Validate First Name- display error if empty
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please enter first name.")
            txtFirstName.BackColor = Color.Yellow     'Set color to yellow
            txtFirstName.Focus()    'set focus back to errored cell for user
            Return False
        Else
            FirstName = txtFirstName.Text
            Return True
        End If

    End Function

    'Create Function to Validate Last Name
    Function ValidateLastName(ByRef LastName As String) As Boolean

        'Validate First Name- display error if empty
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter last name.")
            txtLastName.BackColor = Color.Yellow     'Set color to yellow
            txtLastName.Focus()    'set focus back to errored cell for user
            Return False
        Else
            LastName = txtLastName.Text
            Return True
        End If

    End Function

    'Create Function to Validate Previous Earnings
    Function ValidatePreviousEarnings(ByRef PreviousEarnings As Double) As Boolean


        'Check Wage to make sure it is Numeric
        If IsNumeric(txtPreviousEarnings.Text) Then
            PreviousEarnings = txtPreviousEarnings.Text

            'Validate that Wage is not negative
            If PreviousEarnings >= 0 Then
                Return True
            Else
                'Display error if negative
                MessageBox.Show("Previous Earnings can not be negative.")
                txtPreviousEarnings.BackColor = Color.Yellow     'Set color to yellow
                txtPreviousEarnings.Focus()    'set focus back to errored cell for user
                Return False
            End If
        Else
            'Display Error if Not Numeric
            MessageBox.Show("Please enter numbers only for Previous Earrnings")
            txtPreviousEarnings.BackColor = Color.Yellow     'Set color to yellow
            txtPreviousEarnings.Focus()    'set focus back to errored cell for user
            Return False
        End If

    End Function

    'Create Function to Validate Wage
    Function ValidateWage(ByRef Wage As Double) As Boolean

        'Check Wage to make sure it is Numeric
        If IsNumeric(txtWage.Text) Then
            Wage = txtWage.Text

            'Validate that Wage is not negative
            If Wage >= 0 Then
                Return True
            Else
                'Display error if negative
                MessageBox.Show("Hourly Wage can not be negative.")
                txtWage.BackColor = Color.Yellow     'Set color to yellow
                txtWage.Focus()    'set focus back to errored cell for user
                Return False
            End If
        Else
            'Display Error if Not Numeric
            MessageBox.Show("Please enter numbers only for Wage")
            txtWage.BackColor = Color.Yellow     'Set color to yellow
            txtWage.Focus()    'set focus back to errored cell for user
            Return False
        End If

    End Function


    'Create Function to Validate Hours Worked
    Function ValidateHrsWorked(ByRef Hours As Double) As Boolean

        'Check Wage to make sure it is Numeric
        If IsNumeric(txtHours.Text) Then
            Hours = txtHours.Text

            'Validate that Wage is not negative
            If Hours >= 0 Then
                Return True
            Else
                'Display error if negative
                MessageBox.Show("Hours Worked can not be negative.")
                txtHours.BackColor = Color.Yellow     'Set color to yellow
                txtHours.Focus()    'set focus back to errored cell for user
                Return False
            End If
        Else
            'Display Error if Not Numeric
            MessageBox.Show("Please enter numbers only for Hours Worked")
            txtHours.BackColor = Color.Yellow     'Set color to yellow
            txtHours.Focus()    'set focus back to errored cell for user
            Return False
        End If


    End Function

    'Create Function to Validate States Combobox
    Function ValidateStates(ByRef States As ComboBox) As Boolean

        'Checking to make sure state has been selected
        If cboState.SelectedIndex = -1 Then
            MessageBox.Show("Please select State.")
            cboState.BackColor = Color.Yellow  ' Set backcolor to yellow
            cboState.Focus()  ' set focus on errored cell
            Return False
        Else
            Return True
        End If

    End Function

    'Calculate Gross Pay
    Function CalcGrossPay(ByVal Wage As Double, ByVal Hours As Double) As Double

        'Create Variable to hold tax
        Dim dblGross As Double

        'Calculate Gross pay
        If Hours <= 40 Then
            dblGross = (Hours * Wage)
        Else
            dblGross = (Wage * 40) + ((Wage * 1.5) * (Hours - 40))
        End If

        'Return Gross Pay Result
        Return dblGross

    End Function

    'Calculate State Tax
    Function CalcStateTax(ByVal States As ComboBox, ByVal Gross As Double) As Double

        'Create Variable to hold State tax
        Dim dblStateTax As Double

        'Declare Variables
        Const cdblOhioTax As Double = 0.065
        Const cdblKentuckyTax As Double = 0.06
        Const cdblIndianaTax As Double = 0.055

        'Calculate State Tax
        If cboState.Text.ToUpper = "OHIO" Then
            dblStateTax = (cdblOhioTax * Gross)
        Else
            If cboState.Text.ToUpper = "KENTUCKY" Then
                dblStateTax = (cdblKentuckyTax * Gross)
            Else
                If cboState.Text.ToUpper = "INDIANA" Then
                    dblStateTax = (cdblIndianaTax * Gross)
                End If
            End If
        End If

        'Return Result
        Return dblStateTax

    End Function

    Private Sub Display(ByRef Net As Double, ByRef FICA As Double, ByRef StateTax As Double, ByRef FedTax As Double, ByRef Gross As Double)

        ' display the amounts formatted with headers and separaters
        lstResults.Items.Add("")
        lstResults.Items.Add(" Net Pay: " & vbTab & Net.ToString("C"))
        lstResults.Items.Add("")
        lstResults.Items.Add(" FICA: " & vbTab & vbTab & FICA.ToString("C"))
        lstResults.Items.Add("")
        lstResults.Items.Add(" State Tax: " & vbTab & StateTax.ToString("C"))
        lstResults.Items.Add("")
        lstResults.Items.Add(" Federal Tax: " & vbTab & FedTax.ToString("C"))
        lstResults.Items.Add("")
        lstResults.Items.Add(" Gross Pay: " & vbTab & Gross.ToString("C"))
        lstResults.Items.Add("")
        lstResults.Items.Add("--------------------------------------------------------------------")

    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click

        'Call Calculate Button subroutine
        btnCalculate_Click(sender, e)

    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFormToolStripMenuItem.Click

        'Call Clear Button subroutine
        btnClear_Click(sender, e)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        'Call Exit Button subroutine
        btnExit_Click(sender, e)

    End Sub
End Class