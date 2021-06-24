'*********************************************
' Neina Cichon
' April 21, 2020
' Programming 1
' Payroll Program
'*********************************************

Module PayrollModule

    'Calculate FICA
    Public Function CalcFICA(ByVal PreviousEarnings As Double, ByVal Gross As Double) As Double

        'Create Variable to hold tax
        Dim dblFICA As Double

        'Create Constants and assign values
        Const cdblMedicareTax As Double = 0.0145
        Const cdblSSTax As Double = 0.062
        Const cdblSSMax As Double = 125000

        'Calculate FICA taxes
        If (PreviousEarnings) >= cdblSSMax Then
            dblFICA = (Gross * cdblMedicareTax)
        Else
            If (PreviousEarnings + Gross) < cdblSSMax Then
                dblFICA = (Gross * cdblMedicareTax) + (Gross * cdblSSTax)
            Else
                dblFICA = ((cdblSSMax - PreviousEarnings) * cdblSSTax) + (Gross * cdblMedicareTax)
            End If
        End If

        'Return FICA Result
        Return dblFICA

    End Function

    'Calculate Federal Tax
    Public Function CalcFedTax(ByVal Gross As Double) As Double

        'Create variable to hold Federal Tax
        Dim dblFedTax

        'Calculate Fed Tax
        Select Case Gross
            Case 0 To 50
                dblFedTax = 0
            Case 51 To 500
                dblFedTax = 0.1 * (Gross - 51)
            Case 501 To 2500
                dblFedTax = 45 + (0.15 * (Gross - 500))
            Case 2501 To 5000
                dblFedTax = 345 + (0.2 * (Gross - 2500))
            Case Else
                dblFedTax = 845 + (0.25 * (Gross - 5000))
        End Select

        'Return Result for Federal Tax
        Return dblFedTax

    End Function

    'Calculate Net Pay
    Public Function CalcNetPay(ByVal Gross As Double, ByVal FICA As Double, ByVal StateTax As Double, ByVal FedTax As Double) As Double

        'Create Variable to hold Net Pay
        Dim dblNetPay As Double

        'Calculate Net Pay
        dblNetPay = Gross - FICA - StateTax - FedTax

        'Return Result of Net Pay
        Return dblNetPay

    End Function

End Module
